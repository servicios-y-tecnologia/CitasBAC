using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BACWebAPI.Models
{

    public class BACObject
    {
        public List<BACWSModel> dataList { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }


    public class Producto
    {
       public string tipo {  get; set; }
       public DateTime fecha { get; set; }
       public string cuenta {  get; set; }
       public double valor { get; set; }

    }

    public class BACWSModel
    {
        public string NumeroTarjeta { get; set; }
        public string Cuenta { get; set; }
        public string Cif { get; set; }
        public string InteresesPorCobrar { get; set; }
        public string Triad { get; set; }
        public string MatrizRetencion { get; set; }
        public string ClasificacionCuenta { get; set; }
        public string EstatusCuenta { get; set; }
        public string Atrasos { get; set; }
        public string Sobregiro { get; set; }
        public string Limite { get; set; }
        public string SaldoVencido { get; set; }
        public string CKDevuelto { get; set; }
        public string FlagRECTodo { get; set; }
        public string Antiguedad { get; set; }
        public string QtyOtrasCuentas { get; set; }
        public string TipoCIF { get; set; }
        public string Segmento { get; set; }
        public string Emisor { get; set; }
        public string RACV { get; set; }
        public string Facturacion { get; set; }
        public string Pasivos { get; set; }
        public string Hipotecas { get; set; }
        public string Autos { get; set; }
        public string PPersonal { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}