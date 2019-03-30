using appcitas.ClaseBase;
using System;

namespace appcitas.Dtos
{
    public class ResultadoReversionDto
    {
        public Guid ReversionId { get; set; }

        public int ResultadoReversionId { get; set; }
        public string ResultadoReversionDescripcion { get; set; }
        public int CargoAReversar { get; set; }
        public bool ResultadoReversionAceptada { get; set; }

        public int Accion { get; set; }

        public string Mensaje { get; set; }
    }
}