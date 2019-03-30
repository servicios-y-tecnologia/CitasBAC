using System.ComponentModel.DataAnnotations;

namespace appcitas.Models
{
    public class Tramites
    {
        #region Public Properties

        public int Accion { get; set; }

        public int cantidadRegistros { get; set; }

        public string Mensaje { get; set; }

        public string TramiteAbreviatura { get; set; }

        public int TramiteAlertaPrevia { get; set; }

        public string TramiteDescripcion { get; set; }

        public int TramiteDuracion { get; set; }

        [Key]
        public int TramiteId { get; set; }

        public int TramiteTiempoMuerto { get; set; }
        public string TramiteTipoEvaluacion { get; set; }
        public int TramiteToleranciaAlCliente { get; set; }
        public int TramiteToleranciaDelCliente { get; set; }
        public int TramiteToleranciaFinalizacion { get; set; }

        #endregion Public Properties
    }
}