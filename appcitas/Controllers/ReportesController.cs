using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using appcitas.Context;
using appcitas.Models;
using System.Data.Entity;
using appcitas.Repository;
using appcitas.Services;
using System.Threading.Tasks;
using System.IO;
using appcitas.Dtos;

namespace appcitas.Controllers
{
    public class ReportesController : Controller
    {
        private AppcitasContext _context;

        public ReportesController()
        {
            _context = new AppcitasContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard_Atencion_por_tiempo_espera()
        {
            return View();
        }
        public ActionResult Dashboard_razon_cancelacion()
        {
            return View();
        }

        public ActionResult Dashboard_flujo_por_intervalo()
        {
            return View();
        }

        public ActionResult Dashboard_de_efectividad()
        {
            return View();
        }

        public ActionResult Dashboard_citas_programadas()
        {
            return View();
        }

        public ActionResult Dashboard_atencion_asesor_citas_resultado()
        {
            return View();
        }

        public ActionResult Dashboard_atenciones_realizadas()
        {
            return View();
        }

        public ActionResult Dashboard_consolidado()
        {
            return View();
        }
        public ActionResult Dashboard_citas_diarias_razones_cancelacion()
        {
            return View();
        }

        public ActionResult Dashboard_estatus_cita()
        {
            return View();
        }

        public ActionResult Dashboard_atencion_asesor()
        {
            return View();
        }

        public ActionResult Dashboard_comportamiento_incidencia()
        {
            return View();
        }

        public ActionResult Dashboard_MantaDatos()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ReporteCitasPorEstado(int sucursalid, int estadocita, string cmb_cubiculo, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.ReporteCitasPorEstado(sucursalid, estadocita, cmb_cubiculo, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult HorariosDisponibles(int sucursalid, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.HorarioDisponibleCitas(sucursalid, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReporteAtencionPorTiempoEspera(int SucursalId, int tipoCita, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.ReporteAtencionPorTiempoEspera(SucursalId, tipoCita, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReporteDashboardWalkin(int sucursalid, int estadocita, string cmb_cubiculo, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.ReporteDashboardWalkin(sucursalid, estadocita, cmb_cubiculo, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DashboardConsolidado(int sucursalid, int tipoatencion, string cmb_cubiculo, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.DashboardConsolidado(sucursalid, tipoatencion, cmb_cubiculo, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReporteFlujoPorIntervalo(int SucursalId, int tipoCita, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.ReporteFlujoPorIntervalo(SucursalId, tipoCita, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReporteEfectividad(int SucursalId, int tipoCita, string ejecutivo, string tipoRazon, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.ReporteEfectividad(SucursalId, tipoCita, ejecutivo, tipoRazon, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DashboardRazonCancelacion(int SucursalId, int tipoCita, string ejecutivo, string tipoRazon, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.DashboardRazonCancelacion(SucursalId, tipoCita, ejecutivo, tipoRazon, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DashboardCitasProgramadas(int sucursalId, string cubiculoId, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.DashboardCitasProgramadas(sucursalId, cubiculoId, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DashboardAtencionCubiculo(int sucursalId, string cubiculoId, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.GetDashboardAtencionCubiculo(sucursalId, cubiculoId, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DashboardAtencionPorCita(int sucursalId, string cubiculoId, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.GetDashboardAtencionPorCita(sucursalId, cubiculoId, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DashboardResolucionPorCita(int sucursalId, string cubiculoId, string fecha1, string fecha2)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.GetDashboardResolucionPorCita(sucursalId, cubiculoId, fecha1, fecha2), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReporteAtencionesRealizadas(string fecha1, string fecha2, int sucursalid, int tipoatencion)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.ReporteAtencionesRealizadas(sucursalid, fecha1, fecha2, tipoatencion), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReporteCitasDiarias(string fecha1, int sucursalid, int codtiporazon, int codrazon)
        {
            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.ReporteCitasDiarias(sucursalid, fecha1, codtiporazon, codrazon), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Dashboard_comportamiento_incidencia(int SucursalId, int CitaTipo, string fechainicio, string fechafinal)
        {

            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.GetDashboardComportamientoIncidencias(SucursalId, CitaTipo, fechainicio, fechafinal), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Dashboard_MantaDatos(int SucursalId, int CitaTipo, string fechainicio, string fechafinal)
        {

            ReporteRepository DashboardList = new ReporteRepository();
            try
            {
                return Json(DashboardList.GetDashboardMantaDatos(SucursalId, CitaTipo, fechainicio, fechafinal), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                List<Reportes> list = new List<Reportes>();
                Reportes obj = new Reportes();
                obj.Accion = 0;
                obj.Mensaje = ex.Message.ToString();
                list.Add(obj);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Dashboard_Incidencia_Motor()
        {
            ViewBag.IdentificacionesCliente = new List<TiposDeCliente>()
            {
                new TiposDeCliente{ IdTipoCliente=1, DescripcionTipoCliente="Buro" },
                new TiposDeCliente{ IdTipoCliente=2, DescripcionTipoCliente="N/A" },
                new TiposDeCliente{ IdTipoCliente=3, DescripcionTipoCliente="Aplica a Beneficio" },
                new TiposDeCliente{ IdTipoCliente=4, DescripcionTipoCliente="Todas" }
            };
            ViewBag.Segmentos = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "SEGM");
            ViewBag.MotorUtilizado = new List<Motores>
            {
                new Motores{ MotorId = 1, MotorDescripcion ="Flujo de Citas"},
                new Motores{ MotorId = 2, MotorDescripcion ="Herramienta Independiente"},
                new Motores{ MotorId = 3, MotorDescripcion = "Todas" }
            };
            ViewBag.TipoOfrecimientos = new List<TipoOfrecimiento>()
            {
                new TipoOfrecimiento{ IdTipoOfrecimiento=1, DescTipoOfrecimiento="Anualidad"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=2, DescTipoOfrecimiento="Reversion"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=3, DescTipoOfrecimiento="Tasa Anualizada"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=4, DescTipoOfrecimiento="Todas"},
            };
            var sucursalesList = (from SGRC_Sucursal in _context.dbSucursales
                                  select new
                                  {
                                      SGRC_Sucursal.SucursalId,
                                      SGRC_Sucursal.SucursalNombre
                                  }).ToList();
            var count = sucursalesList.Count();
            sucursalesList.Add(new { SucursalId = count + 1, SucursalNombre = "Todas" });
            ViewBag.Canales = sucursalesList;

            return View("Dashboard_Incidencia_Motor");
        }

        [HttpPost]
        public JsonResult GenerarReporteIncidenciaMotor(string TipoCliente, string FechaInicio, string FechaFinal,
            string segmento, string canal, string motor, string tipoOffer)
        {
            try
            {
                var anualidadesRpt = _context.Anualidades.Select(x => new ReporteIncidencia
                {
                    NumeroCuenta = x.NumeroCuenta,
                    Fecha = x.Fecha,
                    Segmento = x.Segmento,
                    Marca = x.Marca,
                    Familia = x.Familia,
                    Canal = ((from s in _context.dbSucursales
                              where s.SucursalId.ToString() == x.CanalOAgencia
                              select new
                              {
                                  s.SucursalNombre
                              }).FirstOrDefault().SucursalNombre),
                    TipoOfrecimiento = "Anualidad",
                    IdentificacionCliente = x.Buro == true ? "Buro" : x.Resultados.Count() <= 0 ? "N/A" : "Aplica a Beneficio",
                    Resultado = x.Resultados.Where(r => r.ResultadoAceptado == true).FirstOrDefault() != null ? x.Resultados.Where(r => r.ResultadoAceptado == true).FirstOrDefault().ItemDeReclamoDescripcion : "N/A",
                    Ejecutivo = x.CreadoPorUsuario,
                    Herramienta = x.Flujo == FlowUtilizado.FlujoDeCitas ? "Flujo de Citas" : "Herramienta Independiente",
                    Mensaje = "Se cargaron los datos correctamente",
                    Accion = 1
                }).ToList();

                var reversionRpt = _context.Reversiones.Select(x => new ReporteIncidencia
                {
                    NumeroCuenta = x.NumeroCuenta,
                    Fecha = x.Fecha,
                    Segmento = x.Segmento,
                    Marca = x.Marca,
                    Familia = x.Familia,
                    TipoOfrecimiento = "Reversion",
                    Canal = ((from s in _context.dbSucursales
                              where s.SucursalId.ToString() == x.CanalOAgencia
                              select new
                              {
                                  s.SucursalNombre
                              }).FirstOrDefault().SucursalNombre),
                    IdentificacionCliente = x.Buro == true ? "Buro" : x.ResultadosDeReversion.Count() <= 0 ? "N/A" : "Aplica a Beneficio",
                    Resultado = x.ResultadosDeReversion.Count() > 0 ? "Reversar " + x.ResultadosDeReversion.Count().ToString() + "Cargos" : "N/A",
                    Ejecutivo = x.CreadoPorUsuario,
                    Herramienta = x.Flujo == FlowUtilizado.FlujoDeCitas ? "Flujo de Citas" : "Herramienta Independiente",
                    Mensaje = "Se cargaron los datos correctamente",
                    Accion = 1
                }).ToList();
                var tasaRpt = _context.Tasas.Select(x => new ReporteIncidencia
                {
                    NumeroCuenta = x.NumeroCuenta,
                    Fecha = x.Fecha,
                    Segmento = x.Segmento,
                    TipoOfrecimiento = "Tasa Anualizada",
                    Marca = x.Marca,
                    Familia = x.Familia,
                    Canal = ((from s in _context.dbSucursales
                              where s.SucursalId.ToString() == x.CanalOAgencia
                              select new
                              {
                                  s.SucursalNombre
                              }).FirstOrDefault().SucursalNombre),
                    IdentificacionCliente = x.Buro == true ? "Buro" : x.Resultados.Count() <= 0 ? "N/A" : "Aplica a Beneficio",
                    Resultado = x.Resultados.Where(r => r.ResultadoAceptado == true).FirstOrDefault() != null ? x.Resultados.Where(r => r.ResultadoAceptado == true).FirstOrDefault().ItemDeReclamoDescripcion : "N/A",
                    Ejecutivo = x.CreadoPorUsuario,
                    Herramienta = x.Flujo == FlowUtilizado.FlujoDeCitas ? "Flujo de Citas" : "Herramienta Independiente",
                    Mensaje = "Se cargaron los datos correctamente",
                    Accion = 1
                }).ToList();
                var listaRprt = new List<ReporteIncidencia>();
                listaRprt.AddRange(anualidadesRpt);
                listaRprt.AddRange(reversionRpt);
                listaRprt.AddRange(tasaRpt);

                if (listaRprt.Count() <= 0)
                {
                    listaRprt.Add(new ReporteIncidencia
                    {
                        Mensaje = "No se encontraron registros",
                        Accion = 1,
                    });
                }
                else
                {
                    var inicio = DateTime.Parse(FechaInicio);
                    var final = DateTime.Parse(FechaFinal);
                    listaRprt = listaRprt.Where(x => x.Fecha >= inicio
                    && x.Fecha <= final).ToList();

                    if (TipoCliente != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.IdentificacionCliente == TipoCliente).ToList();
                    }

                    if (segmento != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.Segmento == segmento).ToList();
                    }

                    if (canal != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.Canal == canal).ToList();
                    }

                    if (motor != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.Herramienta == motor).ToList();
                    }
                    if (tipoOffer != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.TipoOfrecimiento == tipoOffer).ToList();
                    }
                }



                return Json(listaRprt, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var lista = new List<ReporteIncidencia>()
                {
                    new ReporteIncidencia
                    {
                        Mensaje = ex.Message,
                        Accion = 0,
                    }
                };
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Dashboard_Ofrecimientos()
        {
            ViewBag.IdentificacionesCliente = new List<TiposDeCliente>()
            {
                new TiposDeCliente{ IdTipoCliente=1, DescripcionTipoCliente="Buro" },
                new TiposDeCliente{ IdTipoCliente=2, DescripcionTipoCliente="N/A" },
                new TiposDeCliente{ IdTipoCliente=3, DescripcionTipoCliente="Aplica a Beneficio" },
                new TiposDeCliente{ IdTipoCliente=4, DescripcionTipoCliente="Todas" }
            };
            ViewBag.Segmentos = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "SEGM");
            ViewBag.MotorUtilizado = new List<Motores>
            {
                new Motores{ MotorId = 1, MotorDescripcion ="Flujo de Citas"},
                new Motores{ MotorId = 2, MotorDescripcion ="Herramienta Independiente"},
                new Motores{ MotorId = 3, MotorDescripcion = "Todas" }
            };
            ViewBag.TipoOfrecimientos = new List<TipoOfrecimiento>()
            {
                new TipoOfrecimiento{ IdTipoOfrecimiento=1, DescTipoOfrecimiento="Anualidad"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=2, DescTipoOfrecimiento="Reversion"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=3, DescTipoOfrecimiento="Tasa Anualizada"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=4, DescTipoOfrecimiento="Todas"},
            };
            var sucursalesList = (from SGRC_Sucursal in _context.dbSucursales
                                  select new
                                  {
                                      SGRC_Sucursal.SucursalId,
                                      SGRC_Sucursal.SucursalNombre
                                  }).ToList();
            var count = sucursalesList.Count();
            sucursalesList.Add(new { SucursalId = count + 1, SucursalNombre = "Todas" });
            ViewBag.Canales = sucursalesList;
            return View("Dashboard_Ofrecimientos");
        }

        [HttpPost]
        public JsonResult GenerarReporteOfrecimientos(string TipoCliente, string FechaInicio, string FechaFinal,
            string segmento, string canal, string motor, string tipoOffer)
        {
            try
            {
                var anualidadesRpt = _context.Anualidades.Include(x => x.VariablesEvaluadas)
                    .Select(x => new ReporteIncidencia
                    {
                        NumeroCuenta = x.NumeroCuenta,
                        Fecha = x.Fecha,
                        Segmento = x.Segmento,
                        Marca = x.Marca,
                        Familia = x.Familia,
                        Canal = ((from s in _context.dbSucursales
                                  where s.SucursalId.ToString() == x.CanalOAgencia
                                  select new
                                  {
                                      s.SucursalNombre
                                  }).FirstOrDefault().SucursalNombre),
                        TipoOfrecimiento = "Anualidad",
                        IdentificacionCliente = x.Buro == true ? "Buro" : x.Resultados.Count() <= 0 ? "N/A" : "Aplica a Beneficio",
                        Resultado = x.Resultados.Where(r => r.ResultadoAceptado == true).FirstOrDefault() != null ? x.Resultados.Where(r => r.ResultadoAceptado == true).FirstOrDefault().ItemDeReclamoDescripcion : "N/A",
                        Ejecutivo = x.CreadoPorUsuario,
                        Herramienta = x.Flujo == FlowUtilizado.FlujoDeCitas ? "Flujo de Citas" : "Herramienta Independiente",
                        Mensaje = "Se cargaron los datos correctamente",
                        Accion = 1,
                        ResultadoAceptado = x.ResultadoAceptadoPorCliente,
                        Monto = x.Monto,
                        Variables = x.VariablesEvaluadas.Select(v => new VariablesEval
                        {
                            Item = v.ItemDeReclamoNombre,
                            VariableNombre = v.VariableNombre,
                            ValorActual = v.ValorActual,
                            CondicionLogica = v.CondicionLogica,
                            ValorAEvaluar = v.ValorAEvaluar,
                            EvaluacionCondicion = v.EvaluacionCondicion
                        }).ToList()
                    }).ToList();

                var reversionRpt = _context.Reversiones.Include(x => x.VariablesEvaluadas)
                    .Select(x => new ReporteIncidencia
                    {
                        NumeroCuenta = x.NumeroCuenta,
                        Fecha = x.Fecha,
                        Segmento = x.Segmento,
                        Marca = x.Marca,
                        ResultadoAceptado = x.ResultadoAceptadoPorCliente,
                        Monto = x.Monto_1 + x.Monto_2 + x.Monto_3 + x.Monto_4 + x.Monto_5 + x.Monto_6,
                        Familia = x.Familia,
                        TipoOfrecimiento = "Reversion",
                        Canal = ((from s in _context.dbSucursales
                                  where s.SucursalId.ToString() == x.CanalOAgencia
                                  select new
                                  {
                                      s.SucursalNombre
                                  }).FirstOrDefault().SucursalNombre),
                        IdentificacionCliente = x.Buro == true ? "Buro" : x.ResultadosDeReversion.Count() <= 0 ? "N/A" : "Aplica a Beneficio",
                        Resultado = x.ResultadosDeReversion.Count() > 0 ? "Reversar " + x.ResultadosDeReversion.Count().ToString() + "Cargos" : "N/A",
                        Ejecutivo = x.CreadoPorUsuario,
                        Herramienta = x.Flujo == FlowUtilizado.FlujoDeCitas ? "Flujo de Citas" : "Herramienta Independiente",
                        Mensaje = "Se cargaron los datos correctamente",
                        Accion = 1,
                        Variables = x.VariablesEvaluadas.Select(v => new VariablesEval
                        {
                            Item = v.ItemDeReclamoNombre,
                            VariableNombre = v.VariableNombre,
                            ValorActual = v.ValorActual,
                            CondicionLogica = v.CondicionLogica,
                            ValorAEvaluar = v.ValorAEvaluar,
                            EvaluacionCondicion = v.EvaluacionCondicion
                        }).ToList()
                    }).ToList();
                var tasaRpt = _context.Tasas.Include(x => x.VariablesEvaluadas)
                    .Select(x => new ReporteIncidencia
                    {
                        NumeroCuenta = x.NumeroCuenta,
                        Fecha = x.Fecha,
                        Segmento = x.Segmento,
                        TipoOfrecimiento = "Tasa Anualizada",
                        Marca = x.Marca,
                        Familia = x.Familia,
                        Canal = ((from s in _context.dbSucursales
                                  where s.SucursalId.ToString() == x.CanalOAgencia
                                  select new
                                  {
                                      s.SucursalNombre
                                  }).FirstOrDefault().SucursalNombre),
                        IdentificacionCliente = x.Buro == true ? "Buro" : x.Resultados.Count() <= 0 ? "N/A" : "Aplica a Beneficio",
                        Resultado = x.Resultados.Where(r => r.ResultadoAceptado == true).FirstOrDefault() != null ? x.Resultados.Where(r => r.ResultadoAceptado == true).FirstOrDefault().ItemDeReclamoDescripcion : "N/A",
                        Ejecutivo = x.CreadoPorUsuario,
                        ResultadoAceptado = x.ResultadoAceptadoPorCliente,
                        Herramienta = x.Flujo == FlowUtilizado.FlujoDeCitas ? "Flujo de Citas" : "Herramienta Independiente",
                        Mensaje = "Se cargaron los datos correctamente",
                        Accion = 1,
                        Variables = x.VariablesEvaluadas.Select(v => new VariablesEval
                        {
                            Item = v.ItemDeReclamoNombre,
                            VariableNombre = v.VariableNombre,
                            ValorActual = v.ValorActual,
                            CondicionLogica = v.CondicionLogica,
                            ValorAEvaluar = v.ValorAEvaluar,
                            EvaluacionCondicion = v.EvaluacionCondicion
                        }).ToList()
                    }).ToList();
                var listaRprt = new List<ReporteIncidencia>();
                listaRprt.AddRange(anualidadesRpt);
                listaRprt.AddRange(reversionRpt);
                listaRprt.AddRange(tasaRpt);

                if (listaRprt.Count() <= 0)
                {
                    listaRprt.Add(new ReporteIncidencia
                    {
                        Mensaje = "No se encontraron registros",
                        Accion = 1,
                    });
                }
                else
                {
                    var inicio = DateTime.Parse(FechaInicio);
                    var final = DateTime.Parse(FechaFinal);
                    listaRprt = listaRprt.Where(x => x.Fecha >= inicio
                    && x.Fecha <= final).ToList();

                    if (TipoCliente != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.IdentificacionCliente == TipoCliente).ToList();
                    }

                    if (segmento != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.Segmento == segmento).ToList();
                    }

                    if (canal != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.Canal == canal).ToList();
                    }

                    if (motor != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.Herramienta == motor).ToList();
                    }
                    if (tipoOffer != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.TipoOfrecimiento == tipoOffer).ToList();
                    }
                }



                return Json(listaRprt, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var lista = new List<ReporteIncidencia>()
                {
                    new ReporteIncidencia
                    {
                        Mensaje = ex.Message,
                        Accion = 0,
                    }
                };
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Dashboard_Reversiones()
        {
            ViewBag.IdentificacionesCliente = new List<TiposDeCliente>()
            {
                new TiposDeCliente{ IdTipoCliente=1, DescripcionTipoCliente="Buro" },
                new TiposDeCliente{ IdTipoCliente=2, DescripcionTipoCliente="N/A" },
                new TiposDeCliente{ IdTipoCliente=3, DescripcionTipoCliente="Aplica a Beneficio" },
                new TiposDeCliente{ IdTipoCliente=4, DescripcionTipoCliente="Todas" }
            };
            ViewBag.Segmentos = _context.ItemsDeConfiguracion.Where(x => x.ConfigID == "SEGM");
            ViewBag.MotorUtilizado = new List<Motores>
            {
                new Motores{ MotorId = 1, MotorDescripcion ="Flujo de Citas"},
                new Motores{ MotorId = 2, MotorDescripcion ="Herramienta Independiente"},
                new Motores{ MotorId = 3, MotorDescripcion = "Todas" }
            };
            ViewBag.TipoOfrecimientos = new List<TipoOfrecimiento>()
            {
                new TipoOfrecimiento{ IdTipoOfrecimiento=1, DescTipoOfrecimiento="Anualidad"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=2, DescTipoOfrecimiento="Reversion"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=3, DescTipoOfrecimiento="Tasa Anualizada"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=4, DescTipoOfrecimiento="Todas"},
            };
            var sucursalesList = (from SGRC_Sucursal in _context.dbSucursales
                                  select new
                                  {
                                      SGRC_Sucursal.SucursalId,
                                      SGRC_Sucursal.SucursalNombre
                                  }).ToList();
            var count = sucursalesList.Count();
            sucursalesList.Add(new { SucursalId = count + 1, SucursalNombre = "Todas" });
            ViewBag.Canales = sucursalesList;
            return View("Dashboard_Reversiones");
        }

        [HttpPost]
        public JsonResult GenerarReporteReversiones(string FechaInicio, string FechaFinal, string canal, string motor)
        {
            try
            {

                var anualidadesRpt = _context.Anualidades.Include(x => x.VariablesEvaluadas).Include(x=>x.Resultados)
                    .Where(x=>x.ResultadoAceptadoPorCliente == true && x.Resultados.Count()>0)
                    .Select(x => new ReporteIncidencia
                    {
                        NumeroCuenta = x.NumeroCuenta,
                        Fecha = x.Fecha,
                        Segmento = x.Segmento,
                        Marca = x.Marca,
                        Familia = x.Familia,
                        Canal = ((from s in _context.dbSucursales
                                  where s.SucursalId.ToString() == x.CanalOAgencia
                                  select new
                                  {
                                      s.SucursalNombre
                                  }).FirstOrDefault().SucursalNombre),
                        TipoOfrecimiento = "Anualidad",
                        Herramienta = x.Flujo == FlowUtilizado.FlujoDeCitas ? "Flujo de Citas" : "Herramienta Independiente",
                        Mensaje = "Se cargaron los datos correctamente",
                        Accion = 1,
                        Monto = x.Monto                        
                    }).ToList();

                var reversionRpt = _context.Reversiones.Include(x => x.VariablesEvaluadas).Include(x=>x.ResultadosDeReversion)
                    .Where(x => x.ResultadoAceptadoPorCliente == true && x.ResultadosDeReversion.Count()>0)
                    .Select(x => new ReporteIncidencia
                    {
                        NumeroCuenta = x.NumeroCuenta,
                        Fecha = x.Fecha,
                        Segmento = x.Segmento,
                        Marca = x.Marca,
                        Monto = x.Monto_1 + x.Monto_2 + x.Monto_3 + x.Monto_4 + x.Monto_5 + x.Monto_6,
                        Familia = x.Familia,
                        TipoOfrecimiento = "Reversion",
                        Canal = ((from s in _context.dbSucursales
                                  where s.SucursalId.ToString() == x.CanalOAgencia
                                  select new
                                  {
                                      s.SucursalNombre
                                  }).FirstOrDefault().SucursalNombre),
                        Herramienta = x.Flujo == FlowUtilizado.FlujoDeCitas ? "Flujo de Citas" : "Herramienta Independiente",
                        Mensaje = "Se cargaron los datos correctamente",
                        Accion = 1
                    }).ToList();

                var listaRprt = new List<ReporteIncidencia>();
                listaRprt.AddRange(anualidadesRpt);
                listaRprt.AddRange(reversionRpt);                

                if (listaRprt.Count() <= 0)
                {
                    listaRprt.Add(new ReporteIncidencia
                    {
                        Mensaje = "No se encontraron registros",
                        Accion = 0,
                    });
                }
                else
                {
                    var inicio = DateTime.Parse(FechaInicio);
                    var final = DateTime.Parse(FechaFinal);
                    listaRprt = listaRprt.Where(x => x.Fecha >= inicio
                    && x.Fecha <= final).ToList();
                    
                    if (canal != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.Canal == canal).ToList();
                    }

                    if (motor != "Todas")
                    {
                        listaRprt = listaRprt.Where(x => x.Herramienta == motor).ToList();
                    }
                }

                return Json(listaRprt, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var tmp = new List<ReporteIncidencia>() { new ReporteIncidencia { Accion = 0, Mensaje = ex.Message } };
                return Json(tmp, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Dashboard_Ofrecimientos2()
        {
            ViewBag.TipoOfrecimientos = new List<TipoOfrecimiento>()
            {
                new TipoOfrecimiento{ IdTipoOfrecimiento=1, DescTipoOfrecimiento="Anualidad"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=2, DescTipoOfrecimiento="Reversion"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=3, DescTipoOfrecimiento="Tasa Anualizada"},
                new TipoOfrecimiento{ IdTipoOfrecimiento=4, DescTipoOfrecimiento="Todas"},
            };
            var sucursalesList = (from SGRC_Sucursal in _context.dbSucursales
                                  select new
                                  {
                                      SGRC_Sucursal.SucursalId,
                                      SGRC_Sucursal.SucursalNombre
                                  }).ToList();
            var count = sucursalesList.Count();
            sucursalesList.Add(new { SucursalId = count + 1, SucursalNombre = "Todas" });
            ViewBag.Canales = sucursalesList;
            return View("Dashboard_Ofrecimientos2");
        }

        [HttpPost]
        public JsonResult GenerarReporteDashboardOfrecimientos2(string FechaInicio, string FechaFinal,
            string canal, string tipoOffer)
        {
            try
            {
                var anualidadesRpt = (from va in _context.VariablesEvaluadasDeAnualidad
                                      group va by new
                                      {
                                          va.ItemDeReclamoNombre,
                                          va.VariableNombre,
                                          va.AnualidadId
                                      } into g
                                      select new Ofrecimientos
                                      {
                                          Canal = (from s in _context.dbSucursales
                                                   join a in _context.Anualidades on s.SucursalId.ToString() equals a.CanalOAgencia
                                                   where a.AnualidadId == g.Key.AnualidadId
                                                   select s.SucursalNombre).FirstOrDefault(),
                                          Tramite = "Anualidad",
                                          Fecha =
                                          ((from a in _context.Anualidades
                                            where a.AnualidadId == g.Key.AnualidadId
                                            select new
                                            {
                                                a.Fecha
                                            }).FirstOrDefault().Fecha),
                                          Item = g.Key.ItemDeReclamoNombre,
                                          Variable = g.Key.VariableNombre,
                                          clientesNOTOk = g.Sum(p => (((Boolean?)p.EvaluacionCondicion ?? false) == false ? 1 : 0)),
                                          porcentajeNOTOk = ((g.Sum(p => (((System.Boolean?)p.EvaluacionCondicion ?? false) == false ? 1 : 0)) / g.Count(p => p.EvaluacionCondicion != null)) * 100),
                                          clientesOk = g.Sum(p => (((System.Boolean?)p.EvaluacionCondicion ?? false) == true ? 1 : 0)),
                                          procentajeOk = ((g.Sum(p => (((System.Boolean?)p.EvaluacionCondicion ?? false) == true ? 1 : 0)) / g.Count(p => p.EvaluacionCondicion != null)) * 100),
                                          Mensaje = "Se cargaron los datos correctamente",
                                          Accion = 1
                                      }).ToList();
                var reversionesRpt = (from va in _context.VariablesEvaluadasDeReversion
                                      group va by new
                                      {
                                          va.ItemDeReclamoNombre,
                                          va.VariableNombre,
                                          va.ReversionId
                                      } into g
                                      select new Ofrecimientos
                                      {
                                          Canal = (from s in _context.dbSucursales
                                                   join a in _context.Reversiones on s.SucursalId.ToString() equals a.CanalOAgencia
                                                   where a.ReversionId == g.Key.ReversionId
                                                   select s.SucursalNombre).FirstOrDefault(),
                                          Tramite = "Reversion",
                                          Fecha =
                                          ((from a in _context.Reversiones
                                            where a.ReversionId == g.Key.ReversionId
                                            select new
                                            {
                                                a.Fecha
                                            }).FirstOrDefault().Fecha),
                                          Item = g.Key.ItemDeReclamoNombre,
                                          Variable = g.Key.VariableNombre,
                                          clientesNOTOk = g.Sum(p => (((Boolean?)p.EvaluacionCondicion ?? false) == false ? 1 : 0)),
                                          porcentajeNOTOk = ((g.Sum(p => (((System.Boolean?)p.EvaluacionCondicion ?? false) == false ? 1 : 0)) / g.Count(p => p.EvaluacionCondicion != null)) * 100),
                                          clientesOk = g.Sum(p => (((System.Boolean?)p.EvaluacionCondicion ?? false) == true ? 1 : 0)),
                                          procentajeOk = ((g.Sum(p => (((System.Boolean?)p.EvaluacionCondicion ?? false) == true ? 1 : 0)) / g.Count(p => p.EvaluacionCondicion != null)) * 100),
                                          Mensaje = "Se cargaron los datos correctamente",
                                          Accion = 1
                                      }).ToList();
                var tasasRpt = (from va in _context.TasasVariablesEvaluadas
                                group va by new
                                {
                                    va.ItemDeReclamoNombre,
                                    va.VariableNombre,
                                    va.TasaId
                                } into g
                                select new Ofrecimientos
                                {
                                    Canal = (from s in _context.dbSucursales
                                             join a in _context.Tasas on s.SucursalId.ToString() equals a.CanalOAgencia
                                             where a.TasaId == g.Key.TasaId
                                             select s.SucursalNombre).FirstOrDefault(),
                                    Tramite = "Tasa Anualizada",
                                    Fecha =
                                    ((from a in _context.Tasas
                                      where a.TasaId == g.Key.TasaId
                                      select new
                                      {
                                          a.Fecha
                                      }).FirstOrDefault().Fecha),
                                    Item = g.Key.ItemDeReclamoNombre,
                                    Variable = g.Key.VariableNombre,
                                    clientesNOTOk = g.Sum(p => (((Boolean?)p.EvaluacionCondicion ?? false) == false ? 1 : 0)),
                                    porcentajeNOTOk = ((g.Sum(p => (((System.Boolean?)p.EvaluacionCondicion ?? false) == false ? 1 : 0)) / g.Count(p => p.EvaluacionCondicion != null)) * 100),
                                    clientesOk = g.Sum(p => (((System.Boolean?)p.EvaluacionCondicion ?? false) == true ? 1 : 0)),
                                    procentajeOk = ((g.Sum(p => (((System.Boolean?)p.EvaluacionCondicion ?? false) == true ? 1 : 0)) / g.Count(p => p.EvaluacionCondicion != null)) * 100),
                                    Mensaje = "Se cargaron los datos correctamente",
                                    Accion = 1
                                }).ToList();

                var listaOfrecimientos = new List<Ofrecimientos>();
                listaOfrecimientos.AddRange(anualidadesRpt);
                listaOfrecimientos.AddRange(reversionesRpt);
                listaOfrecimientos.AddRange(tasasRpt);

                var groupedList = listaOfrecimientos.GroupBy(x => new { x.Canal, x.Item, x.Variable })
                    .Select(grp => grp.ToList()).ToList();

                if (groupedList.Count() <= 0)
                {
                    listaOfrecimientos.Add(new Ofrecimientos
                    {
                        Mensaje = "No se encontraron registros",
                        Accion = 1,
                    });
                    groupedList = listaOfrecimientos.GroupBy(x => new { x.Canal, x.Item, x.Variable })
                    .Select(grp => grp.ToList()).ToList();
                }
                else
                {
                    var inicio = DateTime.Parse(FechaInicio);
                    var final = DateTime.Parse(FechaFinal);
                    groupedList = groupedList.Where(x => x.Select(g=>g.Fecha).FirstOrDefault() >= inicio
                    && x.Select(g => g.Fecha).FirstOrDefault() <= final).ToList();

                    if (canal != "Todas")
                    {
                        groupedList = groupedList.Where(x => x.Select(g=>g.Canal).FirstOrDefault() == canal).ToList();
                    }
                    if (tipoOffer != "Todas")
                    {
                        groupedList = groupedList.Where(x => x.Select(g=>g.Tramite).FirstOrDefault() == tipoOffer).ToList();
                    }
                }

                return Json(groupedList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class Ofrecimientos
    {
        public string Canal { get; set; }
        public string Tramite { get; set; }
        public DateTime Fecha { get; set; }
        public string Item { get; set; }
        public string Variable { get; set; }
        public int clientesNOTOk { get; set; }
        public int porcentajeNOTOk { get; set; }
        public int clientesOk { get; set; }
        public int procentajeOk { get; set; }
        public string Mensaje { get; set; }
        public int Accion { get; set; }
    }

    public class ReversionRprt
    {
        public string TipoReversion { get; set; }
        public decimal MontoReversion { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroCuenta { get; set; }
        public string Segmento { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public string Canal { get; set; }
        public string Herramienta { get; set; }
    }

    public class Motores
    {
        public int MotorId { get; set; }
        public string MotorDescripcion { get; set; }
    }

    public class TiposDeCliente
    {
        public int IdTipoCliente { get; set; }
        public string DescripcionTipoCliente { get; set; }
    }

    public class TipoOfrecimiento
    {
        public int IdTipoOfrecimiento { get; set; }
        public string DescTipoOfrecimiento { get; set; }
    }
}