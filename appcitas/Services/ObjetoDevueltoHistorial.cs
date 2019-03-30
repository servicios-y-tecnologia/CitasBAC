using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appcitas.Services
{
    public class ObjetoDevueltoHistorial
    {
        public string ident_clie { get; set; }
        public string id_tipo_identificacion { get; set; }
        public string estatus { get; set; }
        public string num_refer { get; set; }
        public string historia { get; set; }
        public string Error { get; set; }
    }
}