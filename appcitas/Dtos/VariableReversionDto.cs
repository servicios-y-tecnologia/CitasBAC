using appcitas.ClasesBase;
using System;

namespace appcitas.Dtos
{
    public class VariableReversionDto :  VariablesEvaluadas
    {
        public Guid ReversionId { get; set; }
        //public int CargoNumero { get; set; }
    }
}