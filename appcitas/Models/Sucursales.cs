using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AccesoDatos;
using appcitas.Context;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcitas.Models
{
    public class Sucursales
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SucursalId { get; set; }

        [StringLength(500), Column(TypeName = "VARCHAR")]
        public string SucursalNombre { get; set; }

        [StringLength(50), Column(TypeName = "VARCHAR")]
        public string SucursalAbreviatura { get; set; }

        [StringLength(500), Column(TypeName = "VARCHAR")]
        public string SucursalUbicacion { get; set; }

        public bool SucursalEsCanal { get; set; }
        public bool SucursalEsCentroAtencion { get; set; }

        [StringLength(10), Column(TypeName = "VARCHAR")]
        public string SucursalTipoAtencion { get; set; }

        [StringLength(3), Column(TypeName = "VARCHAR")]
        public string SucursalStatus { get; set; }

        [StringLength(20), Column(TypeName = "VARCHAR")]
        public string SucursalIDAlterno { get; set; }

        [NotMapped]
        public string SucSegmentoId { get; set; }

        [NotMapped]
        public string ConfigItemDescripcion { get; set; }

        [NotMapped]
        public int Accion { get; set; }

        [NotMapped]
        public string Mensaje { get; set; }        
       
    }
}