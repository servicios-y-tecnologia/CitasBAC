using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcitas.Models
{
    public class TasaVariableEvaluada
    {
        [ForeignKey("Tasa")]
        public Guid TasaId { get; set; }

        [ForeignKey("Variable")]
        public string VariableCodigo { get; set; }

        public string VariableNombre { get; set; }

        public Guid VariableDeItemId { get; set; }

        public string ReclamoId { get; set; }

        public string ItemDeReclamoId { get; set; }

        public string ItemDeReclamoNombre { get; set; }

        public virtual Variable Variable { get; set; }

        public string CondicionLogica { get; set; }

        public string ValorActual { get; set; }

        public string ValorAEvaluar { get; set; }

        public bool EvaluacionCondicion { get; set; }

        public virtual Tasa Tasa { get; set; }
    }
}