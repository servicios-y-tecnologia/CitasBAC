using BACWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BACWebAPI.Controllers
{
    public class DWBIController : ApiController
    {
        [HttpGet]
        public IHttpActionResult producto(string pcuenta)
        {
            List<Producto> _listaproducto = new List<Producto>();

            Producto _RACV = new Producto
            {
                cuenta = "8888333344449999",
                fecha = DateTime.Now,
                tipo = "RACV",
                valor = 1
            };
            _listaproducto.Add(_RACV);

            Producto _TRIAD = new Producto
            {
                cuenta = "8888333344449999",
                fecha = DateTime.Now.AddMonths(-1),
                tipo = "TRIAD",
                valor = 3
            };
            _listaproducto.Add(_TRIAD);

            Producto _TRIAD2 = new Producto
            {
                cuenta = "8888333344449999",
                fecha = DateTime.Now.AddMonths(2),
                tipo = "TRIAD",
                valor = 2
            };
            _listaproducto.Add(_TRIAD2);


            return Ok(_listaproducto);
       
        }



    }
}