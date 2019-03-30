using appcitas.Context;
using appcitas.Dtos;
using appcitas.Models;
using appcitas.Repository;
using appcitas.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace appcitas.Controllers
{
    public class CitasController : MyBaseController
    {
        #region Private Fields

        private AppcitasContext _context;

        private Citas pCita = new Citas();

        #endregion Private Fields

        #region Public Constructors

        public CitasController()
        {
            _context = new AppcitasContext();
        }

        #endregion Public Constructors



        #region Public Methods

        [HttpPost]
        public JsonResult AsignarRazon(Citas cita)
        {
            try
            {
                CitaRepository CitaRep = new CitaRepository();
                if (ModelState.IsValid)
                {
                    CitaRep.AsignarRazon(cita);
                }
                return Json(cita, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(cita, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CheckEmisorCuenta(string EmisorCuenta)
        {
            CitaRepository Citas = new CitaRepository();
            try
            {
                return Json(Citas.CheckEmisorCuenta(EmisorCuenta), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Citas> list = new List<Citas>();
                Citas obj = new Citas();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CitaFechaHora(string cubiculoIdGlobal, string fechaGlobal, int CitaIdGlobal)
        {
            //var funcionEnDb = _context.CitasProgramadas;//.Where(f => f.PosicionId == cubiculoIdGlobal && f.CitaFecha.Substring(1,19) == fechaGlobal);

            //if (funcionEnDb == null)
            //{
            //    return Json(false, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    //_context.Funciones.Remove(funcionEnDb);
            //    //_context.SaveChanges();

            //    return Json(true, JsonRequestBehavior.AllowGet);
            //}

            CitaRepository Citas = new CitaRepository();
            try
            {
                return Json(Citas.CheckCitaFecha(cubiculoIdGlobal, fechaGlobal, CitaIdGlobal), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Citas> list = new List<Citas>();
                Citas obj = new Citas();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Clientecancela(int id)
        {
            Citas obj = new Citas();
            CitaRepository ACRep = new CitaRepository();
            try
            {
                if (id > 0)
                {
                    obj = ACRep.Clientecancela(id);
                }
                else
                {
                    obj.Accion = 0;
                    obj.Mensaje = "El parametro tiene un valor incorrecto!";
                }
            }
            catch (Exception ex)
            {
                //throw;
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                //return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ConfiguracionMotor()
        {
            var result = _context.ItemsDeConfiguracion.Where(x => x.ConfigItemID == "MTRVSBL").FirstOrDefault().ConfigItemDescripcion;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult deleteRazon(int citaId, int tipoRazonId, int razonId, string datoExtraId)
        {
            Citas obj = new Citas();
            CitaRepository CitaRep = new CitaRepository();
            try
            {
                if (citaId > 0)
                {
                    obj = CitaRep.deleteRazon(citaId, tipoRazonId, razonId, datoExtraId);
                }
                else
                {
                    obj.Accion = 0;
                    obj.Mensaje = "El parametro tiene un valor incorrecto!";
                }
            }
            catch (Exception ex)
            {
                //throw;

                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                //return Json(list, JsonRequestBehavior.AllowGet);
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<System.Web.Mvc.JsonResult> EnviarEmail(string emailCliente, string nombreCliente, string numeroGestion, string sucursal, string tramite, string fecha, string hora, string horaFinal, string accionCita)
        {
            string mensajeIntro = "";
            string mensajeFooter = "";
            string mensajeTitulo = "";
            string mensajeSaludo = "";
            string mensajeFinal = "";
            string mensajeFinal1 = "";
            string mensajeFinal2 = "";
            string mensajeFinal3 = "";
            string mensajeFinal4 = "";
            string mensajeFinal5 = "";
            string mensajeFinal6 = "";
            string mensajeFinal7 = "";
            string mensajeAsunto = "";

            string[] lines;
            var list = new List<string>();
            var ruta = AppDomain.CurrentDomain.BaseDirectory + @"\Content\Publicidad\CorreoCitas.txt";//(@"Content\Publicidad\CorreoCitas.txt");

            var fileStream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            var file = new System.IO.StreamReader(fileStream, System.Text.Encoding.UTF8, true, 128);
            using (var streamReader = new StreamReader(fileStream, Encoding.GetEncoding("iso-8859-1")))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            lines = list.ToArray();

            mensajeTitulo = lines[0];
            mensajeSaludo = lines[1];
            mensajeIntro = lines[2];
            mensajeFooter = lines[3];
            mensajeFinal = lines[4];
            mensajeFinal1 = lines[5];
            mensajeFinal2 = lines[6];
            mensajeFinal3 = lines[7];
            mensajeFinal4 = lines[8];
            mensajeFinal5 = lines[9];
            mensajeFinal6 = lines[10];
            mensajeFinal7 = lines[11];
            mensajeAsunto = lines[12];

            string asunto = mensajeAsunto + numeroGestion;
            string textoAccion = "creado";
            string recordatorioTexto = "informa";
            //string mensajeIntro = "";
            //string mensajeFooter = "";

            /* Creación de evento (adjunto)*/
            string schLocation = sucursal;
            string schSubject = asunto;
            string schDescription = asunto;
            // System.DateTime schBeginDate = Convert.ToDateTime(fecha+" "+hora);
            //System.DateTime schEndDate = Convert.ToDateTime(fecha + " " + horaFinal);

            //String[] cuerpoCita = { "BEGIN:VCALENDAR",
            //                        "PRODID:-//BAC Credomatic//Panama//Pa",
            //                        "BEGIN:VEVENT",
            //                        "DTSTART:" + schBeginDate.ToUniversalTime().ToString("yyyyMMdd\\THHmmss\\Z"),
            //                        "DTEND:" + schEndDate.ToUniversalTime().ToString("yyyyMMdd\\THHmmss\\Z"),
            //                        "LOCATION:" + schLocation,
            //                        "DESCRIPTION;ENCODING=QUOTED-PRINTABLE:" + schDescription,
            //                        "SUMMARY:" + schSubject,
            //                        "PRIORITY:3",
            //                        "END:VEVENT",
            //                        "END:VCALENDAR" };
            //string hoy = System.DateTime.Now.ToString("yyyyMMddhhmmss");
            //string directorioCita = HttpContext.Server.MapPath(@"\iCal\");
            //directorioCita = directorioCita + "Cita"+hoy+".ics";

            /*using (FileStream fs = new FileStream(directorioCita, FileMode.OpenOrCreate))
            using (StreamWriter str = new StreamWriter(fs))
            {
                str.Flush();
                str.Close();
                fs.Close();
            }*/
            /*  .WriteAllLines */
            /*var tempFile = System.IO.Path.GetTempFileName();

            using (var file = System.IO.File.Create(directorioCita))
            {
                System.IO.File.WriteAllLines(directorioCita, cuerpoCita);
                file.Close();
            }*/
            //directorioCita = "";
            //mensajeIntro = "Nos complace comunicarle que su CITA para el inicio del trámite de cancelación tarjeta de crédito, ha sido confirmada para ser atendida:";
            //mensajeFooter = "Agradecemos su puntualidad, por favor anunciarse a su llegada en la recepción de la sucursal asignada.<br> De no poder asistir a la misma, presentarse en sucursal Centro de Fidelizacion Plaza New York en Panamá para programar una nueva cita y gestionar la cancelación de la tarjeta de crédito.<br><br>Agradecemos su preferencia.";
            switch (accionCita)
            {
                case "1":
                    textoAccion = "creado";
                    asunto = asunto + " creada";
                    break;

                case "2":
                    textoAccion = "modificado";
                    asunto = asunto + " modificada";
                    break;

                case "3":
                    textoAccion = "cancelado";
                    asunto = asunto + " cancelada";
                    mensajeIntro = "BAC – Credomatic le " + recordatorioTexto + " que se ha <b>" + textoAccion + "</b> una cita de atención de acuerdo a su solicitud.";
                    mensajeFooter = "";
                    //directorioCita = "";
                    break;

                case "4":
                    recordatorioTexto = "recuerda";
                    break;
            }
            string tituloCorreo = mensajeTitulo;
            string cuerpoCorreo = "";
            cuerpoCorreo = "<p>Estimado(a): " + nombreCliente + "<br><br>" +
                                "<span>" + mensajeIntro + "</span><br><br>" +
                            "</p>" +
                            "<p><b>Cita No.:</b> " + numeroGestion + "</p>" +
                            "<p><b>Centro de Atención:</b> " + sucursal + "</p>" +
                            "<p><b>Trámite:</b> " + tramite + "</p>" +
                            "<p><b>Fecha:</b> " + fecha + "</p>" +
                            "<p><b>Hora:</b> " + hora + "</p><br>" +
                            "<p><span>" + mensajeFooter + "</span></p>" +
                            "<p>" + mensajeFinal6 + "</p>";
            Citas obj = new Citas();
            try
            {
                await EmailService.EnviarEmail(emailCliente, nombreCliente, tituloCorreo, cuerpoCorreo, asunto, mensajeFinal,
                mensajeFinal1, mensajeFinal2, mensajeFinal3, mensajeFinal4, mensajeFinal5, mensajeFinal7);
                obj.Accion = 1;
                obj.Mensaje = "Correo electrónico enviado exitósamente";
                /*GC.Collect();
                GC.WaitForPendingFinalizers();*/
            }
            catch (Exception ex)
            {
                obj.Accion = 0;
                obj.Mensaje = "No se pudo enviar correo electrónico! " + ex;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAllByCustomerId(string CitaIdentificacion)
        {
            CitaRepository CitaRep = new CitaRepository();
            try
            {
                return Json(CitaRep.GetCitasByIdentificacion(CitaIdentificacion), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //throw;
                List<Citas> list = new List<Citas>();
                Citas obj = new Citas();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetCitasBySucursalyEstado(int sucursalid, int estadocita)
        {
            CitaRepository AtenCitas = new CitaRepository();
            try
            {
                return Json(AtenCitas.GetCitasBySurcursalyEstado(sucursalid, estadocita), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Citas> list = new List<Citas>();
                Citas obj = new Citas();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetCitasProgramadasBySucursal(int sucursalid)
        {
            CitaRepository AtenCitas = new CitaRepository();
            try
            {
                return Json(AtenCitas.GetCitasProgramadasBySurcursal(sucursalid), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Citas> list = new List<Citas>();
                Citas obj = new Citas();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetRazonByTipo(int razonId, int tipoRazonId, string datoExtraId)
        {
            CitaRepository AtenCitas = new CitaRepository();
            try
            {
                return Json(AtenCitas.GetRazonByTipo(razonId, tipoRazonId, datoExtraId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Citas> list = new List<Citas>();
                Citas obj = new Citas();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetRazonesByCita(int CitaId)
        {
            CitaRepository AtenCitas = new CitaRepository();
            try
            {
                return Json(AtenCitas.GetRazonesByCita(CitaId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Citas> list = new List<Citas>();
                Citas obj = new Citas();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetTiempoEspera_CentrosAtencion()
        {
            CitaRepository Citas = new CitaRepository();
            try
            {
                return Json(Citas.GetTiempoEspera_CentrosAtencion());
            }
            catch (Exception ex)
            {
                Citas obj = new Citas();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();

                return Json(obj, JsonRequestBehavior.AllowGet);
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
                    }
                }

                if (anualidad.VariablesEvaluadas != null)
                {
                    foreach (var item in anualidad.VariablesEvaluadas)
                    {
                        item.AnualidadId = anualidad.AnualidadId;
                    }
                }

                anualidad.CreadoPorUsuario = Session["usuario"].ToString();
                var mappedEntity = Mapper.Map<AnualidadDto, Anualidad>(anualidad);
                _context.Anualidades.Add(mappedEntity);


                _context.SaveChanges();

                anualidad.Accion = 1;
                anualidad.Mensaje = "Datos guardados exitosamente!";
                return Json(anualidad, JsonRequestBehavior.AllowGet);
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


                anualidad.Accion = 0;
                anualidad.Mensaje = ex.Message;
                return Json(anualidad, JsonRequestBehavior.AllowGet);
            }
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
                        item.ReversionId = reversion.ReversionId;                      
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
                           // System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

                reversion.Accion = 0;
               // int i = 0;
                foreach (var item in ex.Data.Values)
                {
                    //var dicci = item as Dictionary<string, object>;
                   
                    reversion.Mensaje +=  item;
                }

                reversion.Mensaje += ex.Message;
                return Json(reversion, JsonRequestBehavior.AllowGet);
            }
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
                _context.Tasas.Add(Mapper.Map<TasaDto, Tasa>(tasa));

                _context.SaveChanges();

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
                            if (!ex.Data.Contains(validationError.PropertyName))
                            {
                                ex.Data.Add(validationError.PropertyName, validationError.ErrorMessage);
                            }
                            // System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

                tasa.Accion = 0;
                tasa.Mensaje = ex.Message.ToString();
                return Json(tasa, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Citas/
        public ActionResult Index()
        {
            ViewBag.TiposDeReversion = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TRVSN").ToList();
            ViewBag.TipoDeAnualidades = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TANLD");
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerOpcionDeEvaluacion(string opcionCombo)
        {
            try
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("No se Encontraron datos", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        //public async Task<ActionResult> ObtenerResultadosAnualidad(List<AnualidadVariableEvaluadaDto> dataList, string clasificacion, decimal limite, string id_cli, string formulario = "")
        public ActionResult ObtenerResultadosAnualidad(List<AnualidadVariableEvaluadaDto> dataList, string clasificacion, decimal limite,string id_cli, string formulario="")
        {
            var model = new List<AnualidadResultadoObtenidoDto>();


            try
            {
                ViewBag.Buro = /*await*/ EvaluarBuro.EsBuro(clasificacion, limite, id_cli, StaticStrings.type_cli, StaticStrings.user,
                StaticStrings.app, StaticStrings.referencia1, StaticStrings.referencia2, StaticStrings.token);


                var codegroup = dataList.GroupBy(x => x.CodeGroupVariable);

                // foreach (var item in dataList.GroupBy(x => x.ItemDeReclamoId))
                foreach (var item in codegroup)
                {
                    foreach (var variable in item)
                    {
                        if (variable.CodeGroupVariable == null) { variable.GroupVariable = "AND"; }
                        if (variable.CodeGroupVariable == "null" || variable.CodeGroupVariable == "") { variable.GroupVariable = "AND"; }
                        if (variable.EvaluacionCondicion && variable.GroupVariable == "AND")
                        {
                            if (!model.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                            {
                                model.Add(new AnualidadResultadoObtenidoDto
                                {
                                    ReclamoId = variable.ReclamoId,
                                    ItemDeReclamoId = variable.ItemDeReclamoId,
                                    ItemDeReclamoDescripcion = variable.ItemDeReclamoNombre
                                });
                            }
                        }
                        else if (variable.GroupVariable == "OR")
                        {
                            if (!model.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                            {
                                model.Add(new AnualidadResultadoObtenidoDto
                                {
                                    ReclamoId = variable.ReclamoId,
                                    ItemDeReclamoId = variable.ItemDeReclamoId,
                                    ItemDeReclamoDescripcion = variable.ItemDeReclamoNombre
                                });
                            }
                        }
                        else
                        {
                            if (model.Any(x => x.ItemDeReclamoId == variable.ItemDeReclamoId))
                            {
                                model.Remove(model.
                                    FirstOrDefault(x =>
                                    x.ItemDeReclamoId == variable.ItemDeReclamoId));
                                break;
                            }
                        }
                    }
                }


                //var anul = dataList[0].AnualidadId;
                //var _guid = new Guid("00000000-0000-0000-0000-000000000000");
                //var result = _context.Anualidades.Where(x => x.AnualidadId == anul)
                //            .Where(x => x.ComboId != _guid)
                //            .Select(x => x).ToList();                

                ViewBag.EsComboAnualidad = formulario != "" ? true : false;
            }
            catch (Exception ex)
            {
                var msj = ex.Message;
                //throw;
            }
         

            return Json(new
            {
                statusCode = 1,
                statusMessage = "Se obtuvo resultados",
                resultadosHtml = RenderPartialViewToString("_ResultadosAnualidad", model)
            });
        }

        //public async Task<ActionResult> ObtenerResultadosReversion(List<VariableReversionDto> dataList, string clasificacion, decimal limite, string id_cli, string formulario = "")
        [HttpPost]
        public ActionResult ObtenerResultadosReversion(List<VariableReversionDto> dataList, string clasificacion, decimal limite, string id_cli,string formulario="")
        {
            var listaDeResultados = new List<ResultadoReversionDto>();


            try
            {
                ViewBag.Buro = /*await*/ EvaluarBuro.EsBuro(clasificacion, limite, id_cli, StaticStrings.type_cli, StaticStrings.user,
      StaticStrings.app, StaticStrings.referencia1, StaticStrings.referencia2, StaticStrings.token);

                var codegroup = dataList.GroupBy(x => x.CodeGroupVariable);

                // foreach (var item in dataList.GroupBy(x => x.ItemDeReclamoId))
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
                            if (listaDeResultados.Any(x => x.ResultadoReversionDescripcion.Contains(variable.CargoNumero.ToString())))
                            {
                                listaDeResultados.Remove(listaDeResultados.
                                    FirstOrDefault(x => x.ResultadoReversionDescripcion.Contains(variable.CargoNumero.ToString())));
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                var tmp = new List<AnualidadResultadoObtenidoDto>()
                { new AnualidadResultadoObtenidoDto { Accion = 0, Mensaje = ex.Message.ToString() } };
                // var lista = new List<object>() { tmp };
                return Json(tmp, JsonRequestBehavior.AllowGet);
            }

     


            ViewBag.EsComboReversion = formulario != "" ? true : false;

            return Json(new
            {
                statusCode = 1,
                statusMessage = "Se obtuvo resultados",
                resultadosHtml = RenderPartialViewToString("_ResultadosReversion", listaDeResultados)
            });
        }

        //public async Task<ActionResult> ObtenerResultadosTasa(List<TasaVariableEvaluadaDto> dataList, string clasificacion, decimal limite, string id_cli, string formulario)
        [HttpPost]
        public ActionResult ObtenerResultadosTasa(List<TasaVariableEvaluadaDto> dataList, string clasificacion, decimal limite, string id_cli,string formulario)
        {
            var listaDeResultados = new List<TasaResultadoDto>();

            try
            {
                ViewBag.Buro = /*await*/ EvaluarBuro.EsBuro(clasificacion, limite, id_cli, StaticStrings.type_cli, StaticStrings.user,
    StaticStrings.app, StaticStrings.referencia1, StaticStrings.referencia2, StaticStrings.token);


                var codegroup = dataList.GroupBy(x => x.CodeGroupVariable);

                //  foreach (var item in dataList.GroupBy(x => x.ItemDeReclamoId))
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
                                listaDeResultados.Add(new TasaResultadoDto
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
                                listaDeResultados.Add(new TasaResultadoDto
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

                ViewBag.EsComboTasa = formulario != "" ? true : false;

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
                resultadosHtml = RenderPartialViewToString("_ResultadoTasa", listaDeResultados)
            });
        }

        public ActionResult programacion_cc()
        {
            ViewBag.TiposDeReversion = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TRVSN").ToList();
            ViewBag.TipoDeAnualidades = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "TANLD");
            return View();
        }

        [HttpPost]
        public JsonResult ProgramarCita(Citas cita)
        {
            try
            {
                CitaRepository CitaRep = new CitaRepository();
                if (ModelState.IsValid)
                {
                    CitaRep.ProgramarCita(cita);
                }
                return Json(cita, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(cita, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Save(string obj)
        {
            //JavaScriptSerializer j = new JavaScriptSerializer();
            //object a = j.Deserialize(obj, typeof(object));

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(obj);

            foreach (var item in json)
            {
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(Citas cita)
        {
            try
            {
                CitaRepository CitaRep = new CitaRepository();
                if (ModelState.IsValid)
                {
                    CitaRep.Save(cita);
                }
                return Json(cita, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(cita, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Vista_cita_cliente()
        {
            return View();
        }

        #endregion Public Methods



        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion Protected Methods
    }
}