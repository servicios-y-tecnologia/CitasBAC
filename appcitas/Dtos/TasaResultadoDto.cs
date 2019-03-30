using appcitas.ClasesBase;
using System;

namespace appcitas.Dtos
{
    public class TasaResultadoDto
    {
        public TasaResultadoDto()
        {
            ResultadoAceptado = false;
        }

        public Guid TasaId { get; set; }
        public string ReclamoId { get; set; }

        public string ItemDeReclamoId { get; set; }
        public string ItemDeReclamoDescripcion { get; set; }
        public bool ResultadoAceptado { get; set; }
    }
}