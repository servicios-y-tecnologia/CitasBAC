using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appcitas.Dtos
{
    public class ReporteIncidencia
    {
        public string NumeroCuenta { get; set; }        
        public DateTime Fecha { get; set; }
        public string Segmento { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public string Canal { get; set; }
        public string IdentificacionCliente { get; set; }
        public string Resultado { get; set; }
        public string Ejecutivo { get; set; }
        public string Herramienta { get; set; }
        public string TipoOfrecimiento { get; set; }
        public string Mensaje { get; set; }
        public int Accion { get; set; }
        public decimal Monto { get; set; }
        public bool ResultadoAceptado { get; set; }

        public virtual List<VariablesEval> Variables { get; set; }
    }

    public class VariablesEval
    {
        public string Item { get; set; }
        public string VariableNombre { get; set; }
        public string ValorActual { get; set; }
        public string CondicionLogica { get; set; }
        public string ValorAEvaluar { get; set; }
        public bool EvaluacionCondicion { get; set; }
    }
}