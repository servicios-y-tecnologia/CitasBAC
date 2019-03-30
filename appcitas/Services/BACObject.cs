using System;
using System.Collections.Generic;

namespace appcitas.Services
{
    public class BACObject
    {
        public List<dataList> dataList { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }


    public class Producto
    {
        public string tipo { get; set; }
        public DateTime fecha { get; set; }
        public string cuenta { get; set; }
        public double valor { get; set; }
        public double promedio { get; set; }
        public double penultimo { get; set; }
        public double ultimo { get; set; }
        public double racv { get; set; }

    }
}