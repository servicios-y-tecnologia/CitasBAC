using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appcitas.Models
{
    public class ResultadoReversion
    {
        [ForeignKey("Reversion")]
        public Guid ReversionId { get; set; }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultadoReversionId { get; set; }
        public int CargoAReversar { get; set; }
        public string ResultadoReversionDescripcion { get; set; }
        public bool ResultadoReversionAceptada { get; set; }
        public virtual Reversion Reversion { get; set; }
    }
}