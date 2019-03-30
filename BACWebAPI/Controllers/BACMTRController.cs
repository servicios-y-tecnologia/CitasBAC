using BACWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BACWebAPI.Controllers
{
    public class BACMTRController : ApiController
    {

        // GET: api/BACMTR/GetValuesByCif?val=5
        [HttpGet]
        public IHttpActionResult GetValuesByCif(string val)
        {
            if (val != "908880444")
            {
                return NotFound();
            }
            return Ok();
        }

        //GET: api/BACMTR/GetInfoClientByCif?val=5
        [HttpGet]
        public IHttpActionResult GetInfoClientByCif(string val)
        {
            if (val != "908880444")
            {
                return NotFound();
            }
            return Ok(new BACWSModel
            {
                Cif = "908880444",
                Nombre = "PRUEBAS RETENCIONES",
                Correo = "retenciones@pa.bac.net",
                Telefono = "2345698"
            });
        }

        //GET: api/BACMTR/GetGeneralByTC?val=5
        [HttpGet]
        public IHttpActionResult GetGeneralByTC(string val)
        {
            if (val != "8888333344449999" && val!= "5200570515087277")
            {
                return NotFound();
            }


            BACWSModel _BACWS = new BACWSModel
            {
                NumeroTarjeta = val,
                Cuenta = "3702406435",
                Cif = "908880444",
                InteresesPorCobrar = "10.25",
                Triad = "5.0",
                MatrizRetencion = "25.00",
                ClasificacionCuenta = "1",
                EstatusCuenta = "1",
                Atrasos = "2.0",
                Sobregiro = "55.00",
                Limite = "654.00",
                SaldoVencido = "400.25",
                CKDevuelto = "1.0",
                FlagRECTodo = "1",
                Antiguedad = "2",
                QtyOtrasCuentas = "3",
                TipoCIF = "6",
                Segmento = "D34",
                Emisor = "PRUEBA",
                RACV = "54.00",
                Facturacion = "12.36",
                Pasivos = "48.98",
                Hipotecas = "48.25",
                Autos = "25.23",
                PPersonal = "55.32",
                Nombre = "PRUEBAS RETENCIONES",
                Correo = "retenciones@pa.bac.net",
                Telefono = "2345698"
            };

            if (val == "8888333344449999")
            {
                
            }

            BACObject _list = new BACObject();
            _list.dataList = new List<BACWSModel>();
            _list.dataList.Add(_BACWS);

            return Ok(_list);
        }
    }
}
