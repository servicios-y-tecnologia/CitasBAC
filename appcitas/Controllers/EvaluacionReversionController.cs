using appcitas.Context;
using appcitas.Dtos;
using appcitas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Reflection;
using Expressive;
using appcitas.Models;
using AutoMapper;
using System.Net;
using System.Data.Entity.Validation;

namespace appcitas.Controllers
{
    public class EvaluacionReversionController : MyBaseController
    {
        private AppcitasContext _context;

        public EvaluacionReversionController()
        {
            _context = new AppcitasContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: EvaluacionReversion
        public ActionResult Index()
        {
            var model = new ReversionDto()
            {
                Fecha = DateTime.Now.Date,
                FechaCargo_1 = DateTime.Now.Date,
                FechaCargo_2 = DateTime.Now.Date,
                FechaCargo_3 = DateTime.Now.Date,
                FechaCargo_4 = DateTime.Now.Date,
                FechaCargo_5 = DateTime.Now.Date,
                FechaCargo_6 = DateTime.Now.Date
            };
            ViewBag.TiposDeReversion = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TRVSN").ToList();
            return View(model);
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

        [HttpPost]
        public async Task<ActionResult> EvaluarVariables(DatoDeEvaluacion myData)
        {
            try
            {
                List<VariableReversionDto> variablesEvaluadas = new List<VariableReversionDto>();
                BACObject _BACObject = await BACWS.GetGeneralByTC(myData.Cuenta);                
                var todasVariablesEvaluadas = new List<VariableReversionDto>();                
                List<VariablesAEvaluar> variablesComparativas = new List<VariablesAEvaluar>();

                foreach (var item in myData.Cargos)
                {
                    var variablesPropias = _context.Variables.Where(x => x.OrigenId == "SRC2").ToList();
                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

                    switch (item.tipoReversion)
                    {
                        case "COM Informa":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 3)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("001", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            //}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 12, myData.cuenta) <= 3)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "011";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        case "Mora":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 1)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("002", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            //}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 1, myData.cuenta) <= 1)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "012";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        case "SG":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 1)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("003", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            //}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 12, myData.cuenta) <= 1)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "013";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        case "Ret. EC":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 1)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("004", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            ////}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 12, myData.cuenta) <= 1)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "014";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        case "Cargo Compra de saldo":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 1)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("005", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            //}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 12, myData.cuenta) <= 1)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "015";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        case "Cargo Tasa cero":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 1)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("006", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            //}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 12, myData.cuenta) <= 1)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "016";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        case "Rep. x Deterioro":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 1)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("007", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            //}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 12, myData.cuenta) <= 1)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "017";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        case "Anualidad Diferida":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 2)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("008", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            //}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 12, myData.cuenta) <= 2)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "018";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        case "Reversion PRF":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 3)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("009", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            //}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 12, myData.cuenta) <= 3)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "019";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        case "Cargo Retiro Efectivo":
                            //if (ObtenerRecurrencia(item.tipoReversion, 6, myData.cuenta) <= 1)
                            //{
                                variablesComparativas = ObtenerValoresComparativos("010", myData.Segmento);
                                keyValuePairs.Add("Fecha1", item.FechaCargo);
                                keyValuePairs.Add("Monto", item.monto);
                                keyValuePairs.Add("Limite", _BACObject.dataList.FirstOrDefault().Limite);
                            //}
                            //else if (ObtenerRecurrencia(item.tipoReversion, 12, myData.cuenta) <= 1)
                            //{
                            //    var idParent = "002";
                            //    var idChild = "020";
                            //    variablesComparativas = ObtenerValoresComparativos(idParent, idChild, myData.segmento);
                            //    keyValuePairs.Add("Fecha1", item.fechaCargo);
                            //    keyValuePairs.Add("Monto", item.monto);
                            //    keyValuePairs.Add("Limite", _BACObject.Limite);
                            //}
                            break;
                        default:
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

                return Json(variablesEvaluadas, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<VariableReversionDto> tmp = new List<VariableReversionDto>()
                {
                    new VariableReversionDto { Accion = 0, Mensaje = ex.Message }
                };
                return Json(tmp, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerResultados(List<VariableReversionDto> dataList, string clasificacion, decimal limite, string id_cli,string formulario="")
        {
            var listaDeResultados = new List<ResultadoReversionDto>();

            try
            {

                ViewBag.Buro = await EvaluarBuro.EsBuro(clasificacion, limite, id_cli, StaticStrings.type_cli, StaticStrings.user,
          StaticStrings.app, StaticStrings.referencia1, StaticStrings.referencia2, StaticStrings.token);

                var codegroup = dataList.GroupBy(x => x.CodeGroupVariable);
                //dataList.GroupBy(x => x.CargoNumero)
                foreach (var item in codegroup)
                {
                    foreach (var variable in item)
                    {
                        if (variable.CodeGroupVariable == null) { variable.GroupVariable = "AND"; }
                        if (variable.CodeGroupVariable == "null" || variable.CodeGroupVariable == "") { variable.GroupVariable = "AND"; }
                        if (variable.EvaluacionCondicion && variable.GroupVariable == "AND")
                        {
                            if (!listaDeResultados.Any(x => x.ResultadoReversionDescripcion.Contains(variable.CargoNumero.ToString())))
                            {
                                listaDeResultados.Add(new ResultadoReversionDto
                                {
                                    CargoAReversar = variable.CargoNumero,
                                    ResultadoReversionId = listaDeResultados.Count() + 1,
                                    ResultadoReversionDescripcion = "Reversar cargo numero: " + variable.CargoNumero
                                });
                            }
                        }
                        else if (variable.GroupVariable == "OR")
                        {
                            if (!listaDeResultados.Any(x => x.ResultadoReversionDescripcion.Contains(variable.CargoNumero.ToString())))
                            {
                                listaDeResultados.Add(new ResultadoReversionDto
                                {
                                    CargoAReversar = variable.CargoNumero,
                                    ResultadoReversionId = listaDeResultados.Count() + 1,
                                    ResultadoReversionDescripcion = "Reversar cargo numero: " + variable.CargoNumero
                                });
                            }
                        }
                        else
                        {
                            listaDeResultados = new List<ResultadoReversionDto>();
                            break;
                        }
                    }
                }

                ViewBag.EsComboReversion = formulario != "" ? true : false;

            }
            catch (Exception ex)
            {
                var tmp = new List<AnualidadResultadoObtenidoDto>()
                { new AnualidadResultadoObtenidoDto { Accion = 0, Mensaje = ex.Message.ToString() } };
                // var lista = new List<object>() { tmp };
                return Json(tmp, JsonRequestBehavior.AllowGet);
            }


            return Json(new
            {
                statusCode = 1,
                statusMessage = "Se obtuvo resultados",
                resultadosHtml = RenderPartialViewToString("_ResultadosReversion", listaDeResultados)
            });
        }

        [HttpPost]
        public ActionResult GuardarReversion(ReversionDto reversion)
        {            

            try
            {

                reversion.ReversionId = Guid.NewGuid();
                if (reversion.ResultadosDeReversion != null)
                {
                    foreach (var item in reversion.ResultadosDeReversion)
                    {
                      //  item.rec = "003";
                        item.ReversionId = reversion.ReversionId;
                        
                        //item.ResultadoReversionId = Guid.NewGuid().ToString();
                    }
                }

                if (reversion.VariablesEvaluadas != null)
                {
                    foreach (var item in reversion.VariablesEvaluadas)
                    {
                        item.ReversionId = reversion.ReversionId;
                    }
                }

                var numTarjeta = reversion.NumeroTarjeta;
                var numCuenta = reversion.NumeroCuenta;
                reversion.NumeroCuenta = CryptoService.Encrypt(numCuenta);
                reversion.NumeroTarjeta = CryptoService.Encrypt(numTarjeta);
                reversion.CreadoPorUsuario = Session["usuario"].ToString();
                _context.Reversiones.Add(Mapper.Map<ReversionDto, Reversion>(reversion));

                _context.SaveChanges();

                reversion.NumeroCuenta = numCuenta;
                reversion.NumeroTarjeta = numTarjeta;

                reversion.Accion = 1;
                reversion.Mensaje = "Datos guardados exitosamente!";
                return Json(reversion, JsonRequestBehavior.AllowGet);
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
                            //System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }


                reversion.Accion = 0;
                reversion.Mensaje = ex.Message;
                return Json(reversion, JsonRequestBehavior.AllowGet);
            }
        }

        private int ObtenerRecurrencia(string tipoReversion, int meses, string tarjeta)
        {
            List<CargoData> cargos = new List<CargoData>();
            var reversiones = _context.Reversiones.Where(x => x.NumeroTarjeta == tarjeta);
            foreach (var item in reversiones)
            {
                if (item.FechaCargo_1 != null && item.TipoReversionId_1!=null)
                    cargos.Add(new CargoData
                    {
                        FechaCargo = item.FechaCargo_1.ToString(),
                        monto = item.Monto_1.ToString(),
                        tipoReversion = item.TipoReversion_1,
                    });
                if (item.FechaCargo_2 != null && item.TipoReversionId_2 != null)
                    cargos.Add(new CargoData
                    {
                        FechaCargo = item.FechaCargo_2.ToString(),
                        monto = item.Monto_2.ToString(),
                        tipoReversion = item.TipoReversion_2,
                    });
                if (item.FechaCargo_3 != null && item.TipoReversionId_3 != null)
                    cargos.Add(new CargoData
                    {
                        FechaCargo = item.FechaCargo_3.ToString(),
                        monto = item.Monto_3.ToString(),
                        tipoReversion = item.TipoReversion_3,
                    });
                if (item.FechaCargo_4 != null && item.TipoReversionId_4 != null)
                    cargos.Add(new CargoData
                    {
                        FechaCargo = item.FechaCargo_4.ToString(),
                        monto = item.Monto_4.ToString(),
                        tipoReversion = item.TipoReversion_4,
                    });
                if (item.FechaCargo_5 != null && item.TipoReversionId_5 != null)
                    cargos.Add(new CargoData
                    {
                        FechaCargo = item.FechaCargo_5.ToString(),
                        monto = item.Monto_5.ToString(),
                        tipoReversion = item.TipoReversion_5,
                    });
                if (item.FechaCargo_6 != null && item.TipoReversionId_6 != null)
                    cargos.Add(new CargoData
                    {
                        FechaCargo = item.FechaCargo_6.ToString(),
                        monto = item.Monto_6.ToString(),
                        tipoReversion = item.TipoReversion_6,
                    });
            }

            var resultado = (from r in
                (from r in cargos
                 where r.tipoReversion == tipoReversion
                 && DateTime.Parse(r.FechaCargo) <= Convert.ToDateTime(DateTime.Now).AddMonths(-meses)
                 select new
                 {
                     Dummy = "x"
                 })
                    group r by new { r.Dummy } into g
                    select new
                    {
                        Cuenta = g.Count()
                    }).FirstOrDefault();

            return resultado!=null?resultado.Cuenta : 0;
        }

        #region Metodos para Evaluacion de Variables
        //Metodo que obtiene los valores comparativos de acuerdo al tipo de anualidad y segmento
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                VariableDeItemId = var1.VariableDeItemId,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = v.VariableValor.ToString(),
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = v.VariableValor,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valorActual,
                                ValorAEvaluar = var1.ValorAEvaluar,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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

        //Metodo para evaluar valores comparativos normales contra los valores del WS
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                            var valor = property.GetValue(_BACObject, null);
                            var valoractual = valor == null? "0": property.GetValue(_BACObject).ToString();

                            variablesEvaluadas.Add(new VariableReversionDto
                            {
                                CargoNumero = numeroCargo,
                                VariableCodigo = var1.VariableCodigo,
                                VariableNombre = var1.VariableNombre,
                                VariableDeItemId = var1.VariableDeItemId,
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
                                CondicionLogica = var1.CondicionLogica,
                                ValorActual = valoractual,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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
                                CodeGroupVariable = var1.CodeGroupVariable,
                                GroupVariable = var1.GroupVariable,
                                ReclamoId = var1.ReclamoId,
                                ItemDeReclamoId = var1.ItemDeReclamoId,
                                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                                Variable = var1.Variable,
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

        //Metodo para evaluar valores comparativos con formula contra los valores del WS
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
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
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
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
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
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
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
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
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
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
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
                            CodeGroupVariable = var1.CodeGroupVariable,
                            GroupVariable = var1.GroupVariable,
                            ReclamoId = var1.ReclamoId,
                            ItemDeReclamoId = var1.ItemDeReclamoId,
                            ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                            Variable = var1.Variable,
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

        //Metodo para evaluar valores comparativos de tipo lista o rango contra los valores del WS
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
                CodeGroupVariable = var1.CodeGroupVariable,
                GroupVariable = var1.GroupVariable,
                ReclamoId = var1.ReclamoId,
                ItemDeReclamoId = var1.ItemDeReclamoId,
                ItemDeReclamoNombre = var1.ItemDeReclamoNombre,
                Variable = var1.Variable,
                CondicionLogica = var1.CondicionLogica,
                ValorActual = property.GetValue(_BACObject).ToString(),
                ValorAEvaluar = var1.ValorAEvaluar,
                Accion = 1,
                Mensaje = "Se cargaron los datos correctamente",
                EvaluacionCondicion = igual,
            });
        }

        //Metodo para evaluar valores comparativos de tipo lista o rango contra valores del motor
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
                CodeGroupVariable = variableAEvaluar.CodeGroupVariable,
                GroupVariable = variableAEvaluar.GroupVariable,
                ReclamoId = variableAEvaluar.ReclamoId,
                ItemDeReclamoId = variableAEvaluar.ItemDeReclamoId,
                ItemDeReclamoNombre = variableAEvaluar.ItemDeReclamoNombre,
                Variable = variableAEvaluar.Variable,
                CondicionLogica = variableAEvaluar.CondicionLogica,
                ValorActual = valorActual,
                ValorAEvaluar = variableAEvaluar.ValorAEvaluar,
                Accion = 1,
                Mensaje = "Se cargaron los datos correctamente",
                EvaluacionCondicion = igual,
            });
        }
        #endregion
    }
}

public class DatoDeEvaluacion
{
    public string Cuenta { get; set; }
    public string tipocombo { get; set; }
    public string Segmento { get; set; }
    public string Identidad { get; set; }
    public List<CargoData> Cargos { get; set; }
}

public class CargoData
{
    public int NumeroCargo { get; set; }
    public string FechaCargo { get; set; }
    public string tipoReversion { get; set; }
    public string monto { get; set; }
}
