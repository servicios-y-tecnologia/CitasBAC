using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AccesoDatos;
using appcitas.Context;
using System.Data;
using System.Data.SqlClient;

namespace appcitas.Models
{
    public class Reportes
    {
        [Key]
        public int      CitaId { get; set; }
        public string   CitaIdentificacion { get; set; }
        public string   CitaFecha { get; set; }
        public string   CitaNombre { get; set; }
        public string   CitaCorreoElectronico { get; set; }
        public string   CitaTelefonoCelular { get; set; }
        public string   CitaHora { get; set; }
        public string   CitaHoraInicioCompleta { get; set; }
        public string   CitaHoraFinCompleta { get; set; }
        public string   tramite { get; set; }
        public string DiaSemana { get; set; }
        public string CitaCuenta { get; set; }
        public string CitaTarjeta { get; set; }
        public string Familia { get; set; }
        public string   CitaTicket { get; set; }
        public string segmento { get; set; }
        public string Marca { get; set; }
        public string estado { get; set; }
        public string OrigenCita { get; set; }
        public string   CitaHoraClienteIniciaAtencion { get; set; }
        public string   CitaHoraClienteSaleAtencion { get; set; }
        public int      TiempoEnCita { get; set; }

        public int      CitaTipoId { get; set; }
        public string   CitaTipo { get; set; }
        public int      SucursalId { get; set; }
        public string   sucursal { get; set; }
        public string   PosicionId { get; set; }
        public string posicion { get; set; }
        public string posicionDescripcion { get; set; }
        public string CitaUsuarioAtendio { get; set; }
        public int      citasAtendidas { get; set; }
        public int      citasAbandonadas { get; set; }
        public int      PromedioTiempoEspera { get; set; }
        public int      PromedioTiempoEsperaAbandono { get; set; }
        public int      PromedioTiempoAtencion { get; set; }
        public int      TiempoEspera { get; set; }
        public int      TiempoEsperaAbandono { get; set; }
        public int TiempoAtencion { get; set; }
        public int TramiteDuracion { get; set; }
        public string   Resolucion { get; set; }
        public string Razones { get; set; }
        public string Herramientas { get; set; }
        /* Reporte_Atencion_por_tiempo_espera */
        public int      rango_0_15 { get; set; }
        public int      rango_15_30 { get; set; }
        public int      rango_30_45 { get; set; }
        public int      rango_45_60 { get; set; }
        public int      rango_60_mas { get; set; }
        public int      rango_Total { get; set; }
        public int      suma_0_15 { get; set; }
        public int      suma_15_30 { get; set; }
        public int      suma_30_45 { get; set; }
        public int      suma_45_60 { get; set; }
        public int      suma_60_mas { get; set; }
        public int      acumulado_15 { get; set; }
        public int      acumulado_30 { get; set; }
        public int      acumulado_45 { get; set; }
        public int      acumulado_60 { get; set; }
        public int      acumulado_total { get; set; }
        public int      total_citas { get; set; }
        /*Flujo_por_intervalo*/
        public int      rango0 { get; set; }
        public int      rango1 { get; set; }
        public int      rango2 { get; set; }
        public int      rango3 { get; set; }
        public int      rango4 { get; set; }
        public int      rango5 { get; set; }
        public int      rango6 { get; set; }
        public int      rango7 { get; set; }
        public int      rango8 { get; set; }
        public int      rango9 { get; set; }
        public int      rango10 { get; set; }
        public int      rango11 { get; set; }
        public int      rango12 { get; set; }
        public int      rango13 { get; set; }
        public int      rango14 { get; set; }
        public int      rango15 { get; set; }
        public int      rango16 { get; set; }
        public int      rango17 { get; set; }
        public int      rango18 { get; set; }
        public int      rango19 { get; set; }
        public int      rango20 { get; set; }
        public int      rango21 { get; set; }
        public int      rango22 { get; set; }
        public int      rango23 { get; set; }
        /* Efectividad */
        public string   ejecutivoId { get; set; }
        public int      citas_retenidas { get; set; }
        public int      citas_noRetenidas { get; set; }
        public int      total_retenidas { get; set; }
        public int      total_noRetenidas { get; set; }

        /* Comportamiento de incidencias */

        public string SucursalNombre { get; set; }

        public int CantidadAtendidos { get; set; }

        public int CantidadWalkinAtendidos { get; set; }

        public int CitasVencidas { get; set; }

        public int CitasAbandonadas { get; set; }

        public int AbandonadasWalkin { get; set; }

        public int CitasCanceladas { get; set; }

        public int TotalNoAtendidas { get; set; }

        public decimal Efectividad { get; set; }


        public string CodigoRazon { get; set; }
        public string ListadoExtra { get; set; }
        public string Tarjetas { get; set; }
        public int      Accion { get; set; }
        public string   Mensaje { get; set; }

        public string TipoRazon { get; set; }

        public string ComentResolucion { get; set; }

        public string HoraLLego { get; set; }
        public string SucursalOrigen { get; set; }

        public string SucursalHorarioId { get; set; }
        public string SucursalHorarioInicio { get; set; }
        public string SucursalHorarioFinal { get; set; }
    }
}
