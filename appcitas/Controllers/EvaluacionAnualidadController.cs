using appcitas.Context;
using appcitas.Dtos;
using appcitas.Models;
using appcitas.Services;
using AutoMapper;
using Expressive;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Globalization;
using System.Data.Entity.Validation;

namespace appcitas.Controllers
{
    public class EvaluacionAnualidadController : MyBaseController
    {
        CitasAutoservicioWS.TarjetaDTO card;
        CitasAutoservicioWS.CitasAutoservicioWS citaWS = new CitasAutoservicioWS.CitasAutoservicioWS();
        #region Private Fields

        private AppcitasContext _context;

        #endregion Private Fields

        #region Public Constructors

        public EvaluacionAnualidadController()
        {
            _context = new AppcitasContext();
        }

        #endregion Public Constructors



        #region Public Methods

        //Metodo para evaluar valores comparativos de tipo lista o rango contra valores del motor
        public static void EvaluarValoresDeLista(ref List<AnualidadVariableEvaluadaDto> variablesEvaluadas, VariablesAEvaluar variableAEvaluar, VariableDto variable,
            dataList bacObject, Dictionary<string, object> keyValuePairs)
        {
            var valoresParaEvaluarConDelimitador = variableAEvaluar.ValorAEvaluar.Split("{}".ToCharArray())[1];
            var arregloDeValoresAEvaluar = valoresParaEvaluarConDelimitador.Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();
            bool igual = false;
            string valorActual = "";
            string valorAEvaluar = "";
            var formulaValorAEvaluar = FormulaEvaluator.EvaluarFormulaDeVariable(variableAEvaluar.ValorAEvaluar, keyValuePairs, bacObject).ToString();
            var ExpresionValorAEvaluar = new Expression(formulaValorAEvaluar);
            valorAEvaluar = ExpresionValorAEvaluar.Evaluate().ToString();

            foreach (var item in arregloDeValoresAEvaluar)
            {
                switch (variable.TipoId)
                {
                    case "TIPO1":
                        valorActual = variable.VariableValor;
                        if (item == variable.VariableValor)
                        {
                            igual = true;
                            break;
                        }
                        else igual = false;
                        break;

                    case "TIPO2":
                        var formulaAEvaluar = FormulaEvaluator.EvaluarFormulaDeVariable(variable.VariableFormula, keyValuePairs, bacObject).ToString();
                        var ExpresionAEvaluar = new Expression(formulaAEvaluar);
                        valorActual = ExpresionAEvaluar.Evaluate().ToString();
                        if (item == valorActual)
                        {
                            igual = true;
                            break;
                        }
                        else igual = false;
                        break;

                    default:
                        break;
                }
            }

            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
            {
                VariableCodigo = variableAEvaluar.VariableCodigo,
                VariableNombre = variableAEvaluar.VariableNombre,
                VariableDeItemId = variableAEvaluar.VariableDeItemId,
                ReclamoId = variableAEvaluar.ReclamoId,
                ItemDeReclamoId = variableAEvaluar.ItemDeReclamoId,
                ItemDeReclamoNombre = variableAEvaluar.ItemDeReclamoNombre,
                Variable = variableAEvaluar.Variable,
                CondicionLogica = variableAEvaluar.CondicionLogica,
                ValorActual = valorActual,
                ValorAEvaluar = valorAEvaluar,
                CodeGroupVariable = variableAEvaluar.CodeGroupVariable,
                GroupVariable = variableAEvaluar.GroupVariable,
                Accion = 1,
                Mensaje = "Se cargaron los datos correctamente",
                EvaluacionCondicion = igual,
            });
        }

        //GET: Metodo que busca los datos que el motor debe traer de las tabalas
        [HttpGet]
        public ActionResult BuscarDatosDeCatalogos(string cuenta)
        {
            var obj = (from emisor in _context.DbSetEmisores
                       where emisor.EmisorCuenta == cuenta
                       select new EmisorDto
                       {
                           Segmento =
                           ((from itemConf in _context.ItemsDeConfiguracion
                             where itemConf.ConfigID == "SEGM" && itemConf.ConfigItemID == emisor.SegmentoId
                             select new { itemConf.ConfigItemAbreviatura }).FirstOrDefault().ConfigItemAbreviatura),
                           Marca =
                           ((from itemConf in _context.ItemsDeConfiguracion
                             where itemConf.ConfigID == "MRCA" && itemConf.ConfigItemID == emisor.MarcaId
                             select new { itemConf.ConfigItemAbreviatura }).FirstOrDefault().ConfigItemAbreviatura),
                           Producto = emisor.Producto,
                           Familia = emisor.Familia,
                           SegmentoId = emisor.SegmentoId,
                           MarcaId = emisor.MarcaId,
                       }).FirstOrDefault();

            if (obj != null)
                return Json(obj, JsonRequestBehavior.AllowGet);
            else
            {
                return new HttpNotFoundResult("No se encontraron datos");
            }
        }

        //GET: Metodo de WebService de BusquedaPorCuenta
        [HttpGet]
        public async Task<ActionResult> BuscarPorCuenta(string cuenta)
        {
            var obj = await BACWS.GetValuesByCif(cuenta);
            if (obj != null)
            {
                if (obj.dataList.Count == 0)
                    return new HttpNotFoundResult("No se Encontro ningun dato [Count=0]");

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            return new HttpNotFoundResult("No se Encontro ningun dato [null]");
        }

        //GET: Metodo de WebService de BusquedaPorTarjeta
        [HttpGet]
        public  ActionResult BuscarPorTarjetaAutoServ(string tarjeta)
        {
            string token = Resources.Main.tokenConsultarPorTarjeta;
            card =  citaWS.ConsultarPorTarjeta(token, tarjeta);

            return Json(card, JsonRequestBehavior.AllowGet);
        }

        //GET: Metodo de WebService de BusquedaPorTarjeta
        [HttpGet]
        public async Task<ActionResult> BuscarPorTarjeta(string tarjeta)
        {
            var obj = await BACWS.GetGeneralByTC(tarjeta);
            if (obj != null)
            {
                if (obj.dataList==null)
                    return new HttpNotFoundResult("No se Encontro ningun dato [Count=0]");

                if (obj.dataList.Count == 0)
                    return new HttpNotFoundResult("No se Encontro ningun dato [Count=0]");

                return Json(obj, JsonRequestBehavior.AllowGet);

            }
            return new HttpNotFoundResult("No se Encontro ningun dato [null]");
        }

        //GET: Metodo para Evaluar las variables
        [HttpGet]
        public async Task<ActionResult> EvaluarVariables(string tipoAnualidad, string cuenta, string fechaDeCargo, string segmento, string montoAnualidad, string identidad)
        {
            try
            {
                List<VariablesAEvaluar> variablesValoresComparativos = ObtenerValoresComparativos(tipoAnualidad, segmento);

                BACObject _BACObject = await BACWS.GetGeneralByTC(cuenta);
                var _dataList = _BACObject.dataList;

                var variablesEvaluadas = new List<AnualidadVariableEvaluadaDto>();
                var resultadoVariables = new List<AnualidadVariableEvaluadaDto>();
                var todasVariablesEvaluadas = new List<AnualidadVariableEvaluadaDto>();
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>
                {
                    { "Fecha1", fechaDeCargo },
                    { "Anualidad", montoAnualidad }
                };

                var variablesPropias = _context.Variables.Where(x => x.OrigenId == "SRC2").ToList();

                if (_dataList != null && variablesValoresComparativos != null)
                {
                    PropertyInfo[] properties = typeof(dataList).GetProperties();

                    foreach (var var1 in variablesValoresComparativos)
                    {
                        switch (var1.Variable.OrigenId)
                        {
                            case "SRC1":
                                foreach (var property in properties)
                                {
                                    if (var1.VariableNombre == property.Name)
                                    {
                                        if (var1.ValorAEvaluar.Contains("{"))
                                        {
                                            EvaluarValoresDeLista(_dataList.FirstOrDefault(), ref variablesEvaluadas, var1, property);
                                        }
                                        else if (!var1.ValorAEvaluar.Contains("["))
                                        {
                                            EvaluarOtrosValores(_dataList.FirstOrDefault(), ref variablesEvaluadas, var1, property);
                                        }
                                        else if (var1.ValorAEvaluar.Contains("["))
                                        {
                                            EvaluarValoresDeFormula(_dataList.FirstOrDefault(), ref variablesEvaluadas, var1, property, montoAnualidad);
                                        }
                                    }
                                }
                                break;

                            case "SRC2":
                                foreach (var v in variablesPropias)
                                {
                                    if (var1.ValorAEvaluar.Contains("{"))
                                    {
                                        EvaluarValoresDeLista(ref variablesEvaluadas, var1, Mapper.Map<Variable, VariableDto>(v), _dataList.FirstOrDefault(), keyValuePairs);
                                    }
                                    else if (!var1.ValorAEvaluar.Contains("["))
                                    {
                                        EvaluarOtrosValores(_dataList.FirstOrDefault(), ref variablesEvaluadas, keyValuePairs, var1, v);
                                    }
                                    else if (var1.ValorAEvaluar.Contains("["))
                                    {
                                        EvaluarValoresDeFormula(_dataList.FirstOrDefault(), ref variablesEvaluadas, keyValuePairs, var1, v);
                                    }
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }

                foreach (var variableEval in variablesEvaluadas.GroupBy(x => x.ItemDeReclamoId))
                {
                    foreach (var variablelocal in variableEval)
                    {
                        if (variablelocal.EvaluacionCondicion)
                        {
                            resultadoVariables.Add(variablelocal);
                        }
                        else
                        {
                            resultadoVariables = new List<AnualidadVariableEvaluadaDto>();
                            break;
                        }
                    }
                }

                if (resultadoVariables.Count() == 0)
                {
                    foreach (var variableEval in variablesEvaluadas.GroupBy(x => x.ItemDeReclamoId))
                    {
                        foreach (var variablelocal in variableEval)
                        {
                            todasVariablesEvaluadas.Add(variablelocal);
                        }
                    }
                    int totalvareva = todasVariablesEvaluadas.Count;
                    if (totalvareva == 0) { todasVariablesEvaluadas.Add(new AnualidadVariableEvaluadaDto());  }
                    todasVariablesEvaluadas.FirstOrDefault().Mensaje = "No se obtuvo ningun resultado favorable , total variables evaluadas:["+totalvareva+"]";
                    todasVariablesEvaluadas.GroupBy(x => x.ItemDeReclamoId);
                    return Json(todasVariablesEvaluadas, JsonRequestBehavior.AllowGet);
                }

                return Json(resultadoVariables, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var tmp = new List<AnualidadResultadoObtenidoDto>()
                { new AnualidadResultadoObtenidoDto { Accion = 0, Mensaje = ex.Message.ToString() } };
               // var lista = new List<object>() { tmp };
                return Json(tmp, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GuardarAnualidad(AnualidadDto anualidad)
        {

            try
            {

                anualidad.AnualidadId = Guid.NewGuid();

                if (anualidad.Resultados != null)
                {
                    foreach (var item in anualidad.Resultados)
                    {
                        item.AnualidadId = anualidad.AnualidadId;
                        item.ReclamoId = "001";
                        item.ItemDeReclamoId = Guid.NewGuid().ToString();
                       // _context.ResultadoObtenidosDeAnualidad.Add(Mapper.Map<AnualidadResultadoObtenidoDto, AnualidadResultadoObtenido>(item));
                    }
                }

                //var group = anualidad.VariablesEvaluadas.GroupBy(q => q.ItemDeReclamoId);
                if (anualidad.VariablesEvaluadas != null)
                {
                    foreach (var item in anualidad.VariablesEvaluadas)
                    {
                        item.AnualidadId = anualidad.AnualidadId;
                       // item.VariableDeItemId = Guid.NewGuid();
                        //_context.VariablesEvaluadasDeAnualidad.Add(Mapper.Map<AnualidadVariableEvaluadaDto, AnualidadVariableEvaluada>(item));
                        //if (item.ItemDeReclamoId==null || item.ItemDeReclamoId=="")
                        //{

                        //}
                    }
                }

                anualidad.CreadoPorUsuario = Session["usuario"].ToString();
                var numCuenta = anualidad.NumeroCuenta;
                var tarjeta = anualidad.NumeroTarjeta;
                anualidad.NumeroCuenta = CryptoService.Encrypt(numCuenta);
                anualidad.NumeroTarjeta = CryptoService.Encrypt(tarjeta);
                _context.Anualidades.Add(Mapper.Map<AnualidadDto, Anualidad>(anualidad));
                



                _context.SaveChanges();

                anualidad.NumeroTarjeta = tarjeta;
                anualidad.NumeroCuenta = numCuenta;

                anualidad.Accion = 1;
                anualidad.Mensaje = "Datos guardados exitosamente!";
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbEx = ex as DbEntityValidationException;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            if (!ex.Data.Contains(validationError.PropertyName))
                            {
                                ex.Data.Add(validationError.PropertyName, validationError.ErrorMessage);
                            }
                            // System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

                var tmp = new List<AnualidadResultadoObtenidoDto>()
                { new AnualidadResultadoObtenidoDto { Accion = 0, Mensaje = ex.Message.ToString() } };
               
                return Json(tmp, JsonRequestBehavior.AllowGet);
            }


            return Json(anualidad, JsonRequestBehavior.AllowGet);
        }

        // GET: EvaluacionAnualidad
        public ActionResult Index()
        {
            ViewBag.TipoDeAnualidades = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TANLD");
            var model = new AnualidadDto() { Fecha = DateTime.Now.Date, FechaDeCargo = DateTime.Now.Date };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerResultados(List<AnualidadVariableEvaluadaDto> dataList, string clasificacion, decimal limite, string id_cli,string formulario)
        {
            var listaDeResultados = new List<AnualidadResultadoObtenidoDto>();
            try
            {

                ViewBag.Buro = await EvaluarBuro.EsBuro(clasificacion, limite, id_cli, StaticStrings.type_cli, StaticStrings.user,
                    StaticStrings.app, StaticStrings.referencia1, StaticStrings.referencia2, StaticStrings.token);

                //  var itemrid = dataList.GroupBy(x => x.ItemDeReclamoId);
                var codegroup = dataList.GroupBy(x => x.CodeGroupVariable);
                //  var conta = codegroup.Select(x => x.Count());

                foreach (var item in codegroup)
                {
                    foreach (var variable in item)
                    {
                        if (variable.CodeGroupVariable == null) { variable.GroupVariable = "AND"; }
                        if (variable.CodeGroupVariable == "null" || variable.CodeGroupVariable == "") { variable.GroupVariable = "AND"; }
                        if (variable.EvaluacionCondicion && variable.GroupVariable == "AND")
                        {
                            if (!listaDeResultados.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                            {
                                listaDeResultados.Add(new AnualidadResultadoObtenidoDto
                                {
                                    ReclamoId = variable.ReclamoId,
                                    ItemDeReclamoId = variable.ItemDeReclamoId,
                                    ItemDeReclamoDescripcion = variable.ItemDeReclamoNombre
                                });
                            }
                        }
                        else if (variable.GroupVariable == "OR")
                        {
                            if (!listaDeResultados.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                            {
                                listaDeResultados.Add(new AnualidadResultadoObtenidoDto
                                {
                                    ReclamoId = variable.ReclamoId,
                                    ItemDeReclamoId = variable.ItemDeReclamoId,
                                    ItemDeReclamoDescripcion = variable.ItemDeReclamoNombre
                                });
                            }
                        }
                        else
                        {
                            if (listaDeResultados.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                            {
                                listaDeResultados.Remove(listaDeResultados.
                                    FirstOrDefault(x =>
                                    x.ItemDeReclamoId == variable.ItemDeReclamoId));
                                break;
                            }
                        }
                    }
                }

                ViewBag.EsComboAnualidad = formulario != "" ? true : false;
            }
            catch (Exception ex)
            {
                var tmp = new List<AnualidadResultadoObtenidoDto>()
                { new AnualidadResultadoObtenidoDto { Accion = 0, Mensaje = ex.Message.ToString() } };
                // var lista = new List<object>() { tmp };
                return Json(tmp, JsonRequestBehavior.AllowGet);
            }


            ResultadoVM model = new ResultadoVM() { Resultados = listaDeResultados };
            return Json(new
            {
                statusCode = 1,
                statusMessage = "Se obtuvo resultados",
                resultadosHtml = RenderPartialViewToString("_ResultadosDeEvaluacion", model)
            });
        }

        #endregion Public Methods



        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion Protected Methods

        #region Private Methods

        private static void EvaluarOtrosValores(dataList _BACObject, ref List<AnualidadVariableEvaluadaDto> variablesEvaluadas, Dictionary<string, object> keyValuePairs, VariablesAEvaluar var1, Variable v)
        {
            // se comento esto y se agrego la siguiente linea para que funcione y no genere error, pero se deberia revisar bien para ver como es que debe quedar.
            //var formulaValorAEvaluar = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
            //string valorAEvaluar = new Expression(formulaValorAEvaluar.ToString()).Evaluate().ToString();

            string valorAEvaluar = var1.ValorAEvaluar;

            switch (var1.CondicionLogica)
            {
                case "==":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = v.VariableValor.ToString(),
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion = v.VariableValor == var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) == Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case "!=":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = v.VariableValor,
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion = v.VariableValor != var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) != Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case "<=":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) <= Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case ">=":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            string valorActual = "0";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) >= Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case "<":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) < Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case ">":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) > Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        //Metodo para evaluar valores comparativos normales contra los valores del WS
        private static void EvaluarOtrosValores(dataList _BACObject, ref List<AnualidadVariableEvaluadaDto> variablesEvaluadas,
            VariablesAEvaluar var1, PropertyInfo property)
        {
            //var formulaValorAEvaluar = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
            //string valorAEvaluar = new Expression(formulaValorAEvaluar.ToString()).Evaluate().ToString();
            string valorAEvaluar = var1.ValorAEvaluar;

            switch (var1.CondicionLogica)
            {
                case "==":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion = property.GetValue(_BACObject).ToString() == var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        case "DDR6":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) == Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case "!=":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion = property.GetValue(_BACObject).ToString() != var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        case "DDR6":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) != Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case "<=":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) <= Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case ">=":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) >= Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case "<":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = valorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) < Convert.ToDecimal(var1.ValorAEvaluar),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case ">":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":

                            AnualidadVariableEvaluadaDto _test = new AnualidadVariableEvaluadaDto();
                            _test.CargoNumero = 0;
                            _test.VariableCodigo = var1.VariableCodigo;
                            _test.VariableNombre = var1.VariableNombre;
                            _test.VariableDeItemId = var1.VariableDeItemId;
                            _test.ReclamoId = var1.ReclamoId;
                            _test.ItemDeReclamoId = var1.ItemDeReclamoId;
                            _test.ItemDeReclamoNombre = var1.ItemDeReclamoNombre;
                            _test.Variable = var1.Variable;
                            _test.CondicionLogica = var1.CondicionLogica;

                            var valor = property.GetValue(_BACObject,null);
                            if (valor == null) { _test.ValorActual = "0"; } else { _test.ValorActual = property.GetValue(_BACObject).ToString(); }

                            _test.ValorAEvaluar = valorAEvaluar; // este no lo habias puesto, lo aumente.
                            _test.EvaluacionCondicion =
                                Convert.ToDecimal(_test.ValorAEvaluar) > Convert.ToDecimal(var1.ValorAEvaluar);
                            _test.CodeGroupVariable = var1.CodeGroupVariable;
                            _test.GroupVariable = var1.GroupVariable;
                            _test.Accion = 1;
                            _test.Mensaje = "Se cargaron los datos correctamente";
                            variablesEvaluadas.Add(_test);

                            //variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            //{
                            //    CargoNumero = 0,
                            //    VariableCodigo = var1.VariableCodigo,
                            //    VariableNombre = var1.VariableNombre,
                            //    VariableDeItemId = var1.VariableDeItemId,
                            //    ReclamoId = var1.ReclamoId,
                            //    ItemDeReclamoId = var1.ItemDeReclamoId,
                            //    ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            //   // Variable = var1.Variable,
                            //    CondicionLogica = var1.CondicionLogica,
                            //    ValorActual = property.GetValue(_BACObject).ToString(),
                            //    ValorAEvaluar = valorAEvaluar,
                            //    EvaluacionCondicion =
                            //    Convert.ToDecimal(property.GetValue(_BACObject).ToString()) > Convert.ToDecimal(var1.ValorAEvaluar),
                            //    CodeGroupVariable = var1.CodeGroupVariable,
                            //    GroupVariable = var1.GroupVariable,
                            //    Accion = 1,
                            //    Mensaje = "Se cargaron los datos correctamente"
                            //});
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        //Metodo para evaluar valores comparativos con formula contra los valores del WS
        private static void EvaluarValoresDeFormula(dataList bacObject, ref List<AnualidadVariableEvaluadaDto> variablesEvaluadas,
            VariablesAEvaluar var1, PropertyInfo property, string montoAnualidad)
        {
            var parametros = new Dictionary<string, object>
            {
                { "Anualidad", montoAnualidad },
                { "Limite", bacObject.Limite }
            };

            var resultado = FormulaEvaluator.EvaluarFormulaConValoresDeWS(bacObject, var1.ValorAEvaluar, parametros);

            if (var1.Variable.DatoDeRetornoId == "DDR6")
            {
                switch (var1.CondicionLogica)
                {
                    case "==":
                        variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                        {
                            CargoNumero = 0,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = resultado.ToString(),
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) == Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;

                    case "!=":
                        variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                        {
                            CargoNumero = 0,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = resultado.ToString(),
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) != Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;

                    case "<=":
                        variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                        {
                            CargoNumero = 0,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = resultado.ToString(),
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) <= Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;

                    case ">=":
                        variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                        {
                            CargoNumero = 0,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = resultado.ToString(),
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) >= Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;

                    case "<":
                        variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                        {
                            CargoNumero = 0,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = resultado.ToString(),
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) < Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;

                    case ">":
                        variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                        {
                            CargoNumero = 0,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = resultado.ToString(),
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) > Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;

                    default:
                        break;
                }
            }
        }

        //Metodo para evaluar valores comparativos de tipo lista o rango contra los valores del WS
        private static void EvaluarValoresDeLista(dataList _BACObject, ref List<AnualidadVariableEvaluadaDto> variablesEvaluadas,
            VariablesAEvaluar var1, PropertyInfo property)
        {
            var valoresParaEvaluarConDelimitador = var1.ValorAEvaluar.Split("{}".ToCharArray())[1];
            var arregloDeValoresAEvaluar = valoresParaEvaluarConDelimitador.Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();
            bool igual = false;
            foreach (var item in arregloDeValoresAEvaluar)
            {
                if (item == property.GetValue(_BACObject).ToString())
                {
                    igual = true;
                    break;
                }
            }

            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
            {
                CargoNumero = 0,
                VariableCodigo = var1.VariableCodigo,
                VariableNombre = var1.VariableNombre,
                VariableDeItemId = var1.VariableDeItemId,
                ReclamoId = var1.ReclamoId,
                ItemDeReclamoId = var1.ItemDeReclamoId,
                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                Variable = var1.Variable,
                CondicionLogica = var1.CondicionLogica,
                ValorActual = property.GetValue(_BACObject).ToString(),
                ValorAEvaluar = var1.ValorAEvaluar,
                CodeGroupVariable =  var1.CodeGroupVariable,
                GroupVariable = var1.GroupVariable,
                Accion = 1,
                Mensaje = "Se cargaron los datos correctamente",
                EvaluacionCondicion = igual,
            });
        }

        private void EvaluarValoresDeFormula(dataList _BACObject, ref List<AnualidadVariableEvaluadaDto> variablesEvaluadas, Dictionary<string, object> keyValuePairs, VariablesAEvaluar var1, Variable v)
        {
            var resultado = FormulaEvaluator.EvaluarFormulaDeVariable(var1.ValorAEvaluar, keyValuePairs, _BACObject);
            var valorResultado = new Expression(resultado.ToString()).Evaluate().ToString();

            switch (var1.CondicionLogica)
            {
                case "==":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = v.VariableValor.ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion = v.VariableValor == valorResultado,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) == Convert.ToDecimal(valorResultado.ToString()),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case "!=":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = v.VariableValor,
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion = v.VariableValor != valorResultado.ToString(),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) != Convert.ToDecimal(valorResultado.ToString()),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case "<=":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) <= Convert.ToDecimal(valorResultado.ToString()),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case ">=":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            string valorActual = "0";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) >= Convert.ToDecimal(valorResultado.ToString()),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case "<":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) < Convert.ToDecimal(valorResultado.ToString()),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                case ">":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR6":
                            string valorActual = "";
                            if (v.TipoId == "TIPO1")
                                valorActual = v.VariableValor;
                            else if (v.TipoId == "TIPO2")
                            {
                                var formulaResuelta = FormulaEvaluator.EvaluarFormulaDeVariable(v.VariableFormula, keyValuePairs, _BACObject);
                                valorActual = new Expression(formulaResuelta.ToString()).Evaluate().ToString();
                            }
                            variablesEvaluadas.Add(new AnualidadVariableEvaluadaDto
                            {
                                CargoNumero = 0,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) > Convert.ToDecimal(valorResultado.ToString()),
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        //Metodo que obtiene los valores comparativos de acuerdo al tipo de anualidad y segmento
        private List<VariablesAEvaluar> ObtenerValoresComparativos(string tipoAnulidad, string segmento)
        {
            return (from vi in _context.VariablesDeItem.Include(x => x.Variable)
                    join ir in _context.ItemsDeReclamo on vi.ItemDeReclamoId equals ir.ItemDeReclamoId
                    //where vi.ItemDeReclamoId=="004" && vi.ReclamoId ==
                    where vi.ReclamoId ==
                   ((from r in _context.Reclamos
                      where r.ReclamoNombre == "Anualidad"
                      select new
                      {
                          r.ReclamoId
                      }).FirstOrDefault().ReclamoId) &&
                      ir.ItemDeReclamoDescripcion.Contains(tipoAnulidad)
                      && ir.ItemDeReclamoDescripcion.ToLower().Contains(segmento.ToLower())
                    select new VariablesAEvaluar
                    {
                        
                        VariableCodigo = vi.VariableCodigo,
                        CondicionLogica = vi.CondicionLogica,
                        ValorAEvaluar = vi.ValorAEvaluar,
                        ReclamoId = vi.ReclamoId,
                        ItemDeReclamoId = vi.ItemDeReclamoId,
                        ItemDeReclamoNombre = ir.ItemDeReclamoDescripcion,
                        VariableDeItemId = vi.VariableDeItemId,
                        VariableNombre = vi.Variable.VariableNombre,
                        CodeGroupVariable=vi.CodeGroupVariable,
                        GroupVariable=vi.GroupVariable,
                        Variable = new VariableDto
                        {
                            VariableCodigo = vi.Variable.VariableCodigo,
                            VariableNombre = vi.Variable.VariableNombre,
                            OrigenId = vi.Variable.OrigenId,
                            DatoDeRetornoId = vi.Variable.DatoDeRetornoId,
                            TipoId = vi.Variable.TipoId,
                            VariableDescripcion = vi.Variable.VariableDescripcion,
                            VariableFormula = vi.Variable.VariableFormula,
                            VariableValor = vi.Variable.VariableValor
                        }
                    }).ToList();
        }

        #endregion Private Methods
    }

    public class ResultadoVM
    {
        #region Public Properties

        [Display(Name = "Resultados Obtenidos")]
        public List<AnualidadResultadoObtenidoDto> Resultados { get; set; }

        #endregion Public Properties
    }

    public class VariablesAEvaluar
    {
        #region Public Properties

        public string CondicionLogica { get; set; }
        public string ItemDeReclamoId { get; set; }
        public string ItemDeReclamoNombre { get; set; }
        public string ReclamoId { get; set; }
        public string ValorAEvaluar { get; set; }
        public VariableDto Variable { get; set; }
        public string VariableCodigo { get; set; }
        public Guid VariableDeItemId { get; set; }
        public string VariableNombre { get; set; }
        public string CodeGroupVariable { get; set; }
        public string GroupVariable { get; set; }

        #endregion Public Properties
    }
}