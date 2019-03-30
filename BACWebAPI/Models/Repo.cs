using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BACWebAPI.Models
{
    public  class Repo
    {
        List<BACWSModel> misDatos = new List<BACWSModel>();

        public Repo()
        {
            misDatos.Add(new BACWSModel
            {
                NumeroTarjeta = "8888333344449999",
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
                PPersonal = "55.32"
            });
            misDatos.Add(new BACWSModel
            {
                NumeroTarjeta = "8888333344448888",
                Cuenta = "3702406435",
                Cif = "908880444",
                InteresesPorCobrar = "10.25",
                Triad = "570.0",
                MatrizRetencion = "25.00",
                ClasificacionCuenta = "1",
                EstatusCuenta = "1",
                Atrasos = "1.0",
                Sobregiro = "55.00",
                Limite = "654.00",
                SaldoVencido = "0",
                CKDevuelto = "1.0",
                FlagRECTodo = "NULL",
                Antiguedad = "3",
                QtyOtrasCuentas = "3",
                TipoCIF = "6",
                Segmento = "D34",
                Emisor = "PRUEBA",
                RACV = "54.00",
                Facturacion = "178",
                Pasivos = "48.98",
                Hipotecas = "48.25",
                Autos = "25.23",
                PPersonal = "55.32"
            });
        }
    }
}