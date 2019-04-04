using appcitas.Context;
using appcitas.Dtos;
using appcitas.Models;
using appcitas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Expressive;
using AutoMapper;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.Validation;

namespace appcitas.Controllers
{
    public class EvaluacionComboController : Controller
    {
        #region Private Fields

        private AppcitasContext _context;

        #endregion Private Fields

        #region Public Constructors

        public EvaluacionComboController()
        {
            _context = new AppcitasContext();
        }

        #endregion Public Constructors

        #region Protected Constructors
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
      #endregion



        #region Public Methods

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

        public ActionResult TipoCombo(string opcion)
        {
            string nombreview = "~/Views/EvaluacionCombo/";
            object model = null;
            ViewBag.TipoDeAnualidades = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TANLD");
            ViewBag.TiposDeReversion = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TRVSN").ToList();
            try
            {
                const string anualidadtititular = "ANUALIDAD TITULAR";
                const string anualidadadicional = "ADICIONAL";
                const string reversionmora = "REVERSIÓN MORA";
                const string reversionsg = "REVERSIÓN SG";
                const string reversion1 = "REVERSIÓN 1";
                const string reversion2 = "REVERSIÓN 2";
                const string tasas = "TASA";
                switch (opcion.ToUpper())
                {
                    case anualidadtititular:
                        nombreview += "pvwAnualidad.cshtml";
                        model = new AnualidadDto { TipoAnualidadId = "TANLD1", FechaDeCargo = DateTime.Now, Monto = 0 };
                        break;
                    case anualidadadicional:
                        nombreview += "pvwAnualidad.cshtml";
                        model = new AnualidadDto { TipoAnualidadId = "TANLD2", FechaDeCargo=DateTime.Now, Monto =0 };
                        break;
                    case reversionmora:
                        nombreview += "pvwReversion.cshtml";
                        model = new ReversionDto { TipoReversionId_6 = "Mora", TipoReversionId_5 = "Mora", TipoReversionId_4 = "Mora", TipoReversionId_3 = "Mora", TipoReversionId_2 = "Mora", TipoReversionId_1 = "TRVSN2", FechaCargo_1 = DateTime.Now, FechaCargo_2 = DateTime.Now, FechaCargo_3 = DateTime.Now,FechaCargo_4=DateTime.Now,FechaCargo_5=DateTime.Now,FechaCargo_6=DateTime.Now };
                        break;
                    case reversionsg:
                        nombreview += "pvwReversion.cshtml";
                        model = new ReversionDto { TipoReversionId_6 = "SG", TipoReversionId_5 = "SG", TipoReversionId_4 = "SG", TipoReversionId_3 = "SG", TipoReversionId_2 = "SG", TipoReversionId_1 = "TRVSN3", FechaCargo_1 = DateTime.Now, FechaCargo_2 = DateTime.Now, FechaCargo_3 = DateTime.Now, FechaCargo_4 = DateTime.Now, FechaCargo_5 = DateTime.Now, FechaCargo_6 = DateTime.Now };
                        break;
                    case reversion1:
                        nombreview += "pvwReversion.cshtml";
                        model = new ReversionDto { FechaCargo_1 = DateTime.Now, FechaCargo_2 = DateTime.Now, FechaCargo_3 = DateTime.Now, FechaCargo_4 = DateTime.Now, FechaCargo_5 = DateTime.Now, FechaCargo_6 = DateTime.Now };
                        break;
                    case reversion2:
                        nombreview += "pvwReversion.cshtml";
                        model = new ReversionDto { FechaCargo_1 = DateTime.Now, FechaCargo_2 = DateTime.Now, FechaCargo_3 = DateTime.Now, FechaCargo_4 = DateTime.Now, FechaCargo_5 = DateTime.Now, FechaCargo_6 = DateTime.Now };
                        break;
                    case tasas:
                        nombreview += "pvwTasas.cshtml";
                        model = new TasaDto { FechaDelCambio = DateTime.Now };
                        break;
                    default:
                        break;
                }

                
            }
            catch (Exception ex)
            {
                ReversionDto reversion = new ReversionDto();
                reversion.Accion = 0;
                reversion.Mensaje = ex.Message;
                return Json(reversion, JsonRequestBehavior.AllowGet);
            }

            return PartialView(nombreview, model);
        }


        public async Task<ActionResult> EvaluarVariables(DatoDeEvaluacion comboscargoscargos)
        {
            var resultadoVariables = new List<VariableComboDto>();
            List<VariablesAEvaluar> variablesComparativas = new List<VariablesAEvaluar>();
            List<VariableReversionDto> variablesEvaluadas = new List<VariableReversionDto>();
            try
            {
                BACObject _BACObject = await BACWS.GetGeneralByTC(comboscargoscargos.Cuenta);
                var todasVariablesEvaluadas = new List<VariableComboDto>();

                foreach (var item in comboscargoscargos.Cargos)
                {
                    var variablesPropias = _context.Variables.Where(x => x.OrigenId == "SRC2").ToList();
                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

                    switch (item.tipoReversion)
                    {
                        case "COM Informa":
                            variablesComparativas = ObtenerValoresComparativos("001", comboscargoscargos.Segmento);
                            keyValuePairs.Add("Fecha1", item.FechaCargo);
                            keyValuePairs.Add("Monto", item.monto);
                            keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            break;
                        case "Mora":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 1)
                            //{
                            variablesComparativas = ObtenerValoresComparativos("002", comboscargoscargos.Segmento);
                            keyValuePairs.Add("Fecha1", item.FechaCargo);
                            keyValuePairs.Add("Monto", item.monto);
                            keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            break;
                        case "SG":
                            variablesComparativas = ObtenerValoresComparativos("003", comboscargoscargos.Segmento);
                            keyValuePairs.Add("Fecha1", item.FechaCargo);
                            keyValuePairs.Add("Monto", item.monto);
                            keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            break;
                        case "Ret. EC":
                            variablesComparativas = ObtenerValoresComparativos("004", comboscargoscargos.Segmento);
                            keyValuePairs.Add("Fecha1", item.FechaCargo);
                            keyValuePairs.Add("Monto", item.monto);
                            keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            break;

                    }



                    if (_BACObject != null && variablesComparativas != null)
                    {
                        PropertyInfo[] properties = typeof(dataList).GetProperties();

                        foreach (var var1 in variablesComparativas)
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
                                                EvaluarValoresDeLista(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, var1, property, item.NumeroCargo);
                                            }
                                            else if (!var1.ValorAEvaluar.Contains("["))
                                            {
                                                EvaluarOtrosValores(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, var1, property, item.NumeroCargo);
                                            }
                                            else if (var1.ValorAEvaluar.Contains("["))
                                            {
                                                EvaluarValoresDeFormula(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, var1, property, item.monto, item.NumeroCargo);
                                            }
                                        }
                                    }
                                    break;
                                case "SRC2":
                                    foreach (var v in variablesPropias)
                                    {
                                        if (var1.ValorAEvaluar.Contains("{"))
                                        {
                                            EvaluarValoresDeLista(ref variablesEvaluadas, var1, Mapper.Map<Variable, VariableDto>(v), _BACObject.dataList.FirstOrDefault(), keyValuePairs, item.NumeroCargo);
                                        }
                                        else if (!var1.ValorAEvaluar.Contains("["))
                                        {
                                            EvaluarOtrosValores(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, keyValuePairs, var1, v, item.NumeroCargo);
                                        }
                                        else if (var1.ValorAEvaluar.Contains("["))
                                        {
                                            EvaluarValoresDeFormula(_BACObject.dataList.FirstOrDefault(), ref variablesEvaluadas, keyValuePairs, var1, v, item.NumeroCargo);
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }




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


        [HttpPost]
        public ActionResult GuardarCombo(Combo combo)
        {
            try
            {

              //  combo.ComboId = Guid.NewGuid();
                combo.FechaCreacion = DateTime.Now;
                combo.CreadoPor = Session["usuario"].ToString();      

                _context.Combos.Add((combo));
                _context.SaveChanges();               
                
              //  combo.Accion = 1;
               // combo.Mensaje = "Datos guardados exitosamente!";
            }
            catch(DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {

                var tmp = new List<AnualidadResultadoObtenidoDto>()
                { new AnualidadResultadoObtenidoDto { Accion = 0, Mensaje = ex.Message.ToString() } };

                return Json(tmp, JsonRequestBehavior.AllowGet);
            }


            return Json(combo, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult ValidaProcesoCombo(ComboDto combo)
        {
            try
            {
                int contprocess = 0;
                if (combo.ComboId.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    List<Anualidad> _anualidad = (from c in _context.Anualidades
                                         .Where(q => q.ComboId == combo.ComboId)
                                                  select c
                                         ).ToList();

                    List<Reversion> _reversion = (from c in _context.Reversiones
                                                 .Where(q => q.ComboId == combo.ComboId)
                                                  select c
                                                 ).ToList();

                    List<Tasa> _tasas = (from c in _context.Tasas
                                                 .Where(q => q.ComboId == combo.ComboId)
                                         select c
                                                 ).ToList();



                    foreach (var item in _anualidad)
                    {
                        contprocess++;
                    }

                    foreach (var item in _reversion)
                    {
                        contprocess++;
                    }

                    foreach (var item in _tasas)
                    {
                        contprocess++;
                    }


                    if (contprocess == 2)
                    {
                        combo.Accion = 1;
                        combo.Mensaje = "Combo Generado Correctamente";


                    }
                    else
                    {
                        if (_tasas.Count > 0)
                            _context.Tasas.Remove(_tasas[0]);
                        if (_reversion.Count > 0)
                            _context.Reversiones.Remove(_reversion[0]);
                        if (_anualidad.Count > 0)
                            _context.Anualidades.Remove(_anualidad[0]);

                        _context.Combos.Remove(Mapper.Map<ComboDto,Combo>(combo));

                        combo.Accion = 0;
                        combo.Mensaje = "Proceso completado con errores! , volver a intentar";
                    }

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
               
                combo.Accion = 0;
                combo.Mensaje = ex.Message.ToString();
                return Json(combo, JsonRequestBehavior.AllowGet); throw;
            }

            return Json(combo, JsonRequestBehavior.AllowGet);
        }


            // GET: EvaluacionCombo
            public ActionResult Index()
        {
            var model = new ComboDto() { Fecha = DateTime.Now.Date, FechaSegundoCargo = DateTime.Now };
            try
            {
                List<ConfigItem> cargos = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TANLD").ToList();
                cargos.AddRange(_context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TRVSN").ToList());
                ViewBag.Cargos = cargos;
                ViewBag.Combos = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "CMBS");
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
            return View(model);
        }

        #endregion Public Methods

        #region Metodos para Evaluacion de Variables
        //Metodo que obtiene los valores comparativos de acuerdo al tipo de anualidad y segmento
        private void EvaluarValoresDeFormula(dataList _BACObject, ref List<VariableReversionDto> variablesEvaluadas, Dictionary<string, object> keyValuePairs, VariablesAEvaluar var1, Variable v, int numeroCargo)
        {
            var resultado = FormulaEvaluator.EvaluarFormulaDeVariable(var1.ValorAEvaluar, keyValuePairs, _BACObject);
            var valorResultado = new Expression(resultado.ToString()).Evaluate().ToString();

            switch (var1.CondicionLogica)
            {
                case "==":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = v.VariableValor.ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion = v.VariableValor == valorResultado,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = v.VariableValor,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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


        private static void EvaluarOtrosValores(dataList _BACObject, ref List<VariableReversionDto> variablesEvaluadas, Dictionary<string, object> keyValuePairs, VariablesAEvaluar var1, Variable v, int numeroCargo)
        {
            switch (var1.CondicionLogica)
            {
                case "==":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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



        private static void EvaluarOtrosValores(dataList _BACObject, ref List<VariableReversionDto> variablesEvaluadas,
  VariablesAEvaluar var1, PropertyInfo property, int numeroCargo)
        {
            switch (var1.CondicionLogica)
            {
                case "==":
                    switch (var1.Variable.DatoDeRetornoId)
                    {
                        case "DDR1":
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion = property.GetValue(_BACObject).ToString() == var1.ValorAEvaluar,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;
                        case "DDR6":
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
                                EvaluacionCondicion = property.GetValue(_BACObject).ToString() != var1.ValorAEvaluar,
                                Accion = 1,
                                Mensaje = "Se cargaron los datos correctamente"
                            });
                            break;
                        case "DDR6":
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = property.GetValue(_BACObject).ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
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

        private List<VariablesAEvaluar> ObtenerValoresComparativos(string idChild, string segmento)
        {
            return (from vi in _context.VariablesDeItem.Include(x => x.Variable)
                    join ir in _context.ItemsDeReclamo
                          on new { vi.ItemDeReclamoId, vi.ReclamoId }
                      equals new { ir.ItemDeReclamoId, ir.ReclamoId }
                    where
                      vi.ReclamoId == "002" &&
                      vi.ItemDeReclamoId == idChild
                    select new VariablesAEvaluar
                    {
                        VariableCodigo = vi.VariableCodigo,
                        CodeGroupVariable = vi.CodeGroupVariable,
                        GroupVariable = vi.GroupVariable,
                        CondicionLogica = vi.CondicionLogica,
                        ValorAEvaluar = vi.ValorAEvaluar,
                        ReclamoId = vi.ReclamoId,
                        ItemDeReclamoId = vi.ItemDeReclamoId,
                        ItemDeReclamoNombre = ir.ItemDeReclamoDescripcion,
                        VariableDeItemId = vi.VariableDeItemId,
                        VariableNombre = vi.Variable.VariableNombre,
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


        public static void EvaluarValoresDeLista(ref List<VariableReversionDto> variablesEvaluadas, VariablesAEvaluar variableAEvaluar, VariableDto variable,
         dataList bacObject, Dictionary<string, object> keyValuePairs, int numeroCargo)
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

            variablesEvaluadas.Add(new VariableReversionDto
            {
                CargoNumero = numeroCargo,
                VariableCodigo = variableAEvaluar.VariableCodigo,
                VariableNombre = variableAEvaluar.VariableNombre,
                VariableDeItemId = variableAEvaluar.VariableDeItemId,
                ReclamoId = variableAEvaluar.ReclamoId,
                ItemDeReclamoId = variableAEvaluar.ItemDeReclamoId,
                ItemDeReclamoNombre = variableAEvaluar.ItemDeReclamoNombre,
                Variable = variableAEvaluar.Variable,
                CodeGroupVariable = variableAEvaluar.CodeGroupVariable,
                GroupVariable = variableAEvaluar.GroupVariable,
                CondicionLogica = variableAEvaluar.CondicionLogica,
                ValorActual = valorActual,
                ValorAEvaluar = variableAEvaluar.ValorAEvaluar,
                Accion = 1,
                Mensaje = "Se cargaron los datos correctamente",
                EvaluacionCondicion = igual,
            });
        }


        private static void EvaluarValoresDeLista(dataList _BACObject, ref List<VariableReversionDto> variablesEvaluadas,
     VariablesAEvaluar var1, PropertyInfo property, int numeroCargo)
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

            variablesEvaluadas.Add(new VariableReversionDto
            {
                CargoNumero = numeroCargo,
                VariableCodigo = var1.VariableCodigo,
                VariableNombre = var1.VariableNombre,
                VariableDeItemId = var1.VariableDeItemId,
                ReclamoId = var1.ReclamoId,
                ItemDeReclamoId = var1.ItemDeReclamoId,
                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                Variable = var1.Variable,
                CodeGroupVariable = var1.CodeGroupVariable,
                GroupVariable = var1.GroupVariable,
                CondicionLogica = var1.CondicionLogica,
                ValorActual = property.GetValue(_BACObject).ToString(),
                ValorAEvaluar = var1.ValorAEvaluar,
                Accion = 1,
                Mensaje = "Se cargaron los datos correctamente",
                EvaluacionCondicion = igual,
            });
        }


        private static void EvaluarValoresDeFormula(dataList bacObject, ref List<VariableReversionDto> variablesEvaluadas,
    VariablesAEvaluar var1, PropertyInfo property, string monto, int numeroCargo)
        {

            var parametros = new Dictionary<string, object>
            {
                { "Monto", monto },
                { "Limite", bacObject.Limite }
            };

            var resultado = FormulaEvaluator.EvaluarFormulaConValoresDeWS(bacObject, var1.ValorAEvaluar, parametros);

            if (var1.Variable.DatoDeRetornoId == "DDR6")
            {
                switch (var1.CondicionLogica)
                {
                    case "==":
                        variablesEvaluadas.Add(new VariableReversionDto
                        {
                            CargoNumero = numeroCargo,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) == Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case "!=":
                        variablesEvaluadas.Add(new VariableReversionDto
                        {
                            CargoNumero = numeroCargo,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) != Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case "<=":
                        variablesEvaluadas.Add(new VariableReversionDto
                        {
                            CargoNumero = numeroCargo,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) <= Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case ">=":
                        variablesEvaluadas.Add(new VariableReversionDto
                        {
                            CargoNumero = numeroCargo,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) >= Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case "<":
                        variablesEvaluadas.Add(new VariableReversionDto
                        {
                            CargoNumero = numeroCargo,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
                            EvaluacionCondicion =
                                Convert.ToDecimal(property.GetValue(bacObject).ToString()) < Convert.ToDecimal(resultado),
                            Accion = 1,
                            Mensaje = "Se cargaron los datos correctamente"
                        });
                        break;
                    case ">":
                        variablesEvaluadas.Add(new VariableReversionDto
                        {
                            CargoNumero = numeroCargo,
                            VariableCodigo = var1.VariableCodigo,
                            VariableNombre = var1.VariableNombre,
                            VariableDeItemId = var1.VariableDeItemId,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            CondicionLogica = var1.CondicionLogica,
                            ValorActual = property.GetValue(bacObject).ToString(),
                            ValorAEvaluar = var1.ValorAEvaluar,
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


        #endregion




    }
}