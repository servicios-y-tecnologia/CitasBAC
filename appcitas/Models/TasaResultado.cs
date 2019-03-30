using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcitas.Models
{
    public class TasaResultado
    {
        public TasaResultado()
        {
            ResultadoAceptado = false;
        }

        [ForeignKey("Tasa")]
        public Guid TasaId { get; set; }

        public string ReclamoId { get; set; }

        public string ItemDeReclamoId { get; set; }

        public string ItemDeReclamoDescripcion { get; set; }

        public bool ResultadoAceptado { get; set; }

        public virtual Tasa Tasa { get; set; }
    }
}