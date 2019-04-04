using appcitas.Context;
using appcitas.Dtos;
using appcitas.Models;
using appcitas.Services;
using Expressive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using AutoMapper;
using System.Data.Entity.Validation;

namespace appcitas.Controllers
{
    public class EvaluacionTasaController : MyBaseController
    {
        private AppcitasContext _context;

        // GET: EvaluacionTasa
        public ActionResult Index()
        {
            var model = new TasaDto() { Fecha = DateTime.Now };
            return View(model);
        }

        public EvaluacionTasaController()
        {
            _context = new AppcitasContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET: Metodo de WebService de BusquedaPorTarjeta
        [HttpGet]
        public async Task<ActionResult> BuscarPorTarjeta(string tarjeta)
        {
            var obj = await BACWS.GetGeneralByTC(tarjeta);
            if (obj != null)
            {
                if (obj.dataList.Count == 0)
                    return new HttpNotFoundResult("No se Encontro ningun dato [Count=0]");

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            return new HttpNotFoundResult("No se Encontro ningun dato [null]");
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

        [HttpGet]
        public async Task<ActionResult> EvaluarVariables(string cuenta, string fechaDelCambio, string segmento, decimal tasaActual, string identidad)
        {
            try
            {
                List<VariablesAEvaluar> variablesValoresComparativos = ObtenerValoresComparativos(segmento);

                BACObject _BACObject = await BACWS.GetGeneralByTC(cuenta);

                var variablesEvaluadas = new List<TasaVariableEvaluadaDto>();
                var resultadoVariables = new List<TasaVariableEvaluadaDto>();
                var todasVariablesEvaluadas = new List<TasaVariableEvaluadaDto>();
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>
                {
                    { "Fecha1", fechaDelCambio }
                };

                var variablesPropias = _context.Variables.Where(x => x.OrigenId == "SRC2").ToList();

                if (_BACObject != null && variablesValoresComparativos != null)
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
                                            EvaluarValoresDeLista(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, var1, property);
                                        }
                                        else if (!var1.ValorAEvaluar.Contains("["))
                                        {
                                            EvaluarOtrosValores(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, var1, property);
                                        }
                                        else if (var1.ValorAEvaluar.Contains("["))
                                        {
                                            EvaluarValoresDeFormula(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, var1, property);
                                        }
                                    }
                                }
                                break;
                            case "SRC2":
                                foreach (var v in variablesPropias)
                                {
                                    if (var1.ValorAEvaluar.Contains("{"))
                                    {
                                        EvaluarValoresDeLista(ref variablesEvaluadas, var1, Mapper.Map<Variable, VariableDto>(v), _BACObject.dataList.FirstOrDefault(), keyValuePairs);
                                    }
                                    else if (!var1.ValorAEvaluar.Contains("["))
                                    {
                                        EvaluarOtrosValores(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, keyValuePairs, var1, v);
                                    }
                                    else if (var1.ValorAEvaluar.Contains("["))
                                    {
                                        EvaluarValoresDeFormula(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, keyValuePairs, var1, v);
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
                            resultadoVariables = new List<TasaVariableEvaluadaDto>();
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
                    todasVariablesEvaluadas.FirstOrDefault().Mensaje = "No se obtuve ningun resultado favorable";
                    todasVariablesEvaluadas.GroupBy(x => x.ItemDeReclamoId);
                    return Json(todasVariablesEvaluadas, JsonRequestBehavior.AllowGet);
                }

                return Json(resultadoVariables, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var tmp = new AnualidadResultadoObtenidoDto() { Accion = 0, Mensaje = ex.Message.ToString() };
                var lista = new List<object>() { tmp };
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerResultados(List<TasaVariableEvaluadaDto> dataList, string clasificacion, decimal limite, string id_cli, string formulario = "")
        //public ActionResult ObtenerResultados(List<TasaVariableEvaluadaDto> dataList, string clasificacion, decimal limite, string id_cli,string formulario="")
        {
            var listaDeResultados = new List<TasaResultadoDto>();

            try
            {
                ViewBag.Buro = await EvaluarBuro.EsBuro(clasificacion, limite, id_cli, StaticStrings.type_cli, StaticStrings.user,
              StaticStrings.app, StaticStrings.referencia1, StaticStrings.referencia2, StaticStrings.token);

                var codegroup = dataList.GroupBy(x => new { x.ItemDeReclamoId, x.CodeGroupVariable });
                //var codegroup = dataList.GroupBy(x => x.CodeGroupVariable);
                //dataList.GroupBy(x => x.ItemDeReclamoId)
                foreach (var item in codegroup)
                {
                    foreach (var variable in item)
                    {
                        if (variable.CodeGroupVariable == null) { variable.GroupVariable = "AND"; }
                        if (variable.CodeGroupVariable == "null" || variable.CodeGroupVariable == "") { variable.GroupVariable = "AND"; }

                        // si cumple la evaluacion no importa si es AND o OR, la cumplio
                        if (variable.EvaluacionCondicion)
                        {
                            // agregamos el resultado al combo
                            if (!listaDeResultados.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                            {
                                listaDeResultados.Add(new TasaResultadoDto
                                {
                                    ReclamoId = variable.ReclamoId,
                                    ItemDeReclamoId = variable.ItemDeReclamoId,
                                    ItemDeReclamoDescripcion = variable.ItemDeReclamoNombre
                                });
                            }

                            // si es un OR ya no sigo evaluando porque una cumplio
                            if (variable.GroupVariable == "OR")
                                break;
                        }
                        else // no cumplio la condicion
                        {
                            // si es un AND ya no sigo evaluando porque no cumplio
                            if (variable.GroupVariable == "AND")
                            {
                                if (listaDeResultados.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                                {
                                    listaDeResultados.Remove(listaDeResultados.
                                        FirstOrDefault(x =>
                                        x.ItemDeReclamoId == variable.ItemDeReclamoId));
                                }
                                break;
                            }
                            // si es un OR sigo evaluando
                        }

                        //if (variable.EvaluacionCondicion && variable.GroupVariable == "AND")
                        //{
                        //    if (!listaDeResultados.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                        //    {
                        //        listaDeResultados.Add(new TasaResultadoDto
                        //        {
                        //            ReclamoId = variable.ReclamoId,
                        //            ItemDeReclamoId = variable.ItemDeReclamoId,
                        //            ItemDeReclamoDescripcion = variable.ItemDeReclamoNombre
                        //        });
                        //    }

                        //}
                        //else if (variable.GroupVariable == "OR")
                        //{
                        //    if (!listaDeResultados.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                        //    {
                        //        listaDeResultados.Add(new TasaResultadoDto
                        //        {
                        //            ReclamoId = variable.ReclamoId,
                        //            ItemDeReclamoId = variable.ItemDeReclamoId,
                        //            ItemDeReclamoDescripcion = variable.ItemDeReclamoNombre
                        //        });
                        //    }
                        //}
                        //else
                        //{
                        //    if (listaDeResultados.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                        //    {
                        //        listaDeResultados.Remove(listaDeResultados.
                        //            FirstOrDefault(x =>
                        //            x.ItemDeReclamoId == variable.ItemDeReclamoId));
                        //        break;
                        //    }
                        //}
                    }
                }

                ViewBag.EsComboTasa = formulario != "" ? true : false;

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    statusCode = 1,
                    statusMessage = ex.Message,
                    resultadosHtml = "<div class=\"alert alert-danger\"><strong> Genero un error: "
                  + ex.Message + "  </strong> "
                  + "</div> "
                });
            }

            return Json(new
            {
                statusCode = 1,
                statusMessage = "Se obtuvo resultados",
                resultadosHtml = RenderPartialViewToString("_ResultadosDeEvaluacion", listaDeResultados)
            });
        }

        [HttpPost]
        public ActionResult GuardarTasa(TasaDto tasa)
        {
            tasa.CreadoPorUsuario = Session["usuario"].ToString();
            tasa.TasaId = Guid.NewGuid();
            if (tasa.Resultados != null)
            {
                foreach (var item in tasa.Resultados)
                {
                    item.ReclamoId = "003";
                    item.TasaId = tasa.TasaId;
                    item.ItemDeReclamoId = Guid.NewGuid().ToString();
                }
            }

            if (tasa.VariablesEvaluadas != null)
            {
                foreach (var item in tasa.VariablesEvaluadas)
                {
                    item.TasaId = tasa.TasaId;
                }
            }

            try
            {
                var numCuenta = tasa.NumeroCuenta;
                var numTarjeta = tasa.NumeroTarjeta;
                tasa.NumeroCuenta = CryptoService.Encrypt(numCuenta);
                tasa.NumeroTarjeta = CryptoService.Encrypt(numTarjeta);
                _context.Tasas.Add(Mapper.Map<TasaDto, Tasa>(tasa));

                _context.SaveChanges();

                tasa.NumeroCuenta = numCuenta;
                tasa.NumeroTarjeta = numTarjeta;

                tasa.Accion = 1;
                tasa.Mensaje = "Datos guardados exitosamente!";
                return Json(tasa, JsonRequestBehavior.AllowGet);
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
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

                tasa.Accion = 0;
                tasa.Mensaje = ex.Message.ToString();
                return Json(tasa, JsonRequestBehavior.AllowGet);
            }
        }

        #region Metodos de Evaluacion
        private void EvaluarValoresDeFormula(dataList _BACObject, ref List<TasaVariableEvaluadaDto> variablesEvaluadas, Dictionary<string, object> keyValuePairs, VariablesAEvaluar var1, Variable v)
        {
            var resultado = FormulaEvaluator.EvaluarFormulaDeVariable(var1.ValorAEvaluar, keyValuePairs, _BACObject);
            var valorResultado = new Expression(resultado.ToString()).Evaluate().ToString();

            switch (var1.CondicionLogica)
            {
                case "==":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) == Convert.ToDecimal(valorResultado.ToString()),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion = v.VariableValor != valorResultado.ToString(),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) != Convert.ToDecimal(valorResultado.ToString()),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) <= Convert.ToDecimal(valorResultado.ToString()),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) >= Convert.ToDecimal(valorResultado.ToString()),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) < Convert.ToDecimal(valorResultado.ToString()),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) > Convert.ToDecimal(valorResultado.ToString()),
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

        private static void EvaluarOtrosValores(dataList _BACObject, ref List<TasaVariableEvaluadaDto> variablesEvaluadas, Dictionary<string, object> keyValuePairs, VariablesAEvaluar var1, Variable v)
        {
            switch (var1.CondicionLogica)
            {
                case "==":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion = v.VariableValor == var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) == Convert.ToDecimal(var1.ValorAEvaluar),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion = v.VariableValor != var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) != Convert.ToDecimal(var1.ValorAEvaluar),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) <= Convert.ToDecimal(var1.ValorAEvaluar),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) >= Convert.ToDecimal(var1.ValorAEvaluar),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) < Convert.ToDecimal(var1.ValorAEvaluar),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(valorActual) > Convert.ToDecimal(var1.ValorAEvaluar),
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
        private static void EvaluarOtrosValores(dataList _BACObject, ref List<TasaVariableEvaluadaDto> variablesEvaluadas,
            VariablesAEvaluar var1, PropertyInfo property)
        {
            switch (var1.CondicionLogica)
            {
                case "==":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                            {
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion = property.GetValue(_BACObject).ToString() == var1.ValorAEvaluar,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;
                        case "DDR6":
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                            {
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) == Convert.ToDecimal(var1.ValorAEvaluar),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                            {
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion = property.GetValue(_BACObject).ToString() != var1.ValorAEvaluar,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;
                        case "DDR6":
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                            {
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) != Convert.ToDecimal(var1.ValorAEvaluar),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                            {
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) <= Convert.ToDecimal(var1.ValorAEvaluar),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                            {
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) >= Convert.ToDecimal(var1.ValorAEvaluar),
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
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                            {
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) < Convert.ToDecimal(var1.ValorAEvaluar),
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
                            var valor = property.GetValue(_BACObject, null);
                            var valoractual = valor == null ? "0" : property.GetValue(_BACObject).ToString();
                            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                            {
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual =valoractual,
                                ValorAEvaluar = var1.ValorAEvaluar,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(_BACObject).ToString()) > Convert.ToDecimal(var1.ValorAEvaluar),
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

        //Metodo para evaluar valores comparativos con formula contra los valores del WS
        private static void EvaluarValoresDeFormula(dataList bacObject, ref List<TasaVariableEvaluadaDto> variablesEvaluadas,
            VariablesAEvaluar var1, PropertyInfo property)
        {

            var parametros = new Dictionary<string, object>
            {
                { "Limite", bacObject.Limite }
            };

            var resultado = FormulaEvaluator.EvaluarFormulaConValoresDeWS(bacObject, var1.ValorAEvaluar, parametros);

            if (var1.Variable.DatoDeRetornoId == "DDR6")
            {
                switch (var1.CondicionLogica)
                {
                    case "==":
                        variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                        {
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) == Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case "!=":
                        variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                        {
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) != Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case "<=":
                        variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                        {
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) <= Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case ">=":
                        variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                        {
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) >= Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case "<":
                        variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                        {
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) < Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case ">":
                        variablesEvaluadas.Add(new TasaVariableEvaluadaDto
                        {
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
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
        private static void EvaluarValoresDeLista(dataList _BACObject, ref List<TasaVariableEvaluadaDto> variablesEvaluadas,
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

            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
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
                CodeGroupVariable = var1.CodeGroupVariable,
                GroupVariable = var1.GroupVariable,
                Accion = 1,
                Mensaje = "Se cargaron los datos correctamente",
                EvaluacionCondicion = igual,
            });
        }

        //Metodo para evaluar valores comparativos de tipo lista o rango contra valores del motor
        public static void EvaluarValoresDeLista(ref List<TasaVariableEvaluadaDto> variablesEvaluadas, VariablesAEvaluar variableAEvaluar, VariableDto variable,
            dataList bacObject, Dictionary<string, object> keyValuePairs)
        {
            var valoresParaEvaluarConDelimitador = variableAEvaluar.ValorAEvaluar.Split("{}".ToCharArray())[1];
            var arregloDeValoresAEvaluar = valoresParaEvaluarConDelimitador.Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();
            bool igual = false;
            string valorActual = "";

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

            variablesEvaluadas.Add(new TasaVariableEvaluadaDto
            {
                CargoNumero = 0,
                VariableCodigo = variableAEvaluar.VariableCodigo,
                VariableNombre = variableAEvaluar.VariableNombre,
                VariableDeItemId = variableAEvaluar.VariableDeItemId,
                ReclamoId = variableAEvaluar.ReclamoId,
                ItemDeReclamoId = variableAEvaluar.ItemDeReclamoId,
                ItemDeReclamoNombre = variableAEvaluar.ItemDeReclamoNombre,
                Variable = variableAEvaluar.Variable,
                CondicionLogica = variableAEvaluar.CondicionLogica,
                CodeGroupVariable = variableAEvaluar.CodeGroupVariable,
                GroupVariable = variableAEvaluar.GroupVariable,
                ValorActual = valorActual,
                ValorAEvaluar = variableAEvaluar.ValorAEvaluar,
                Accion = 1,
                Mensaje = "Se cargaron los datos correctamente",
                EvaluacionCondicion = igual,
            });
        }

        //Metodo que obtiene los valores comparativos de acuerdo al tipo de anualidad y segmento
        private List<VariablesAEvaluar> ObtenerValoresComparativos(string segmento)
        {
            return (from vi in _context.VariablesDeItem.Include(x => x.Variable)
                    join ir in _context.ItemsDeReclamo
                          on new { vi.ReclamoId, vi.ItemDeReclamoId }
                      equals new { ir.ReclamoId, ir.ItemDeReclamoId }
                    join r in _context.Reclamos
                          on new { ir.ReclamoId, Column1 = vi.ReclamoId }
                      equals new { r.ReclamoId, Column1 = r.ReclamoId }
                    where
                      r.ReclamoId == "003" &&
                      ir.ItemDeReclamoDescripcion.Contains(segmento)
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
                        CodeGroupVariable = vi.CodeGroupVariable,
                        GroupVariable = vi.GroupVariable,
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
        #endregion
    }
}
