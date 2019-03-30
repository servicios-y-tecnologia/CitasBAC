﻿using appcitas.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcitas.Models
{
    public class Anualidad
    {
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AnualidadId { get; set; }

        public bool Buro { get; set; }
        public string CanalOAgencia { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "CIF")]
        [StringLength(25, ErrorMessage = "Este campo no puede contener mas de 25  caracteres")]
        public string CIF { get; set; }

        public int CitaId { get; set; }

        public string CreadoPorUsuario { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Familia")]
        [StringLength(50, ErrorMessage = "Este campo no puede contener mas de 50 caracteres")]
        public string Familia { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Fecha del Cargo")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FechaDeCargo { get; set; }

        public FlowUtilizado Flujo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Identidad")]
        public string Identidad { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Limite")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Limite { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Marca")]
        [StringLength(50, ErrorMessage = "Este campo no puede ser mas larga de 50 caracteres")]
        public string Marca { get; set; }

        [Required, MaxLength(10), Column(TypeName = "VARCHAR")]
        public string MarcaId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Monto")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Numero de Cuenta")]
        [StringLength(50, ErrorMessage = "Este campo no puede contener mas de 50 caracteres")]
        public string NumeroCuenta { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Numero de Tarjeta")]
        [StringLength(50, ErrorMessage = "Este campo no puede contener mas de 50 caracteres")]
        public string NumeroTarjeta { get; set; }

        [Display(Name = "Observacion")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }

        [Display(Name = "Resultado Aceptado por el cliente")]
        [Required]
        public bool ResultadoAceptadoPorCliente { get; set; }

        public virtual List<AnualidadResultadoObtenido> Resultados { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Saldo Actual")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal SaldoActual { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Segmento")]
        [StringLength(100)]
        public string Segmento { get; set; }

        [Required, MaxLength(10), Column(TypeName = "VARCHAR")]
        public string SegmentoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Tipo de Anualidad")]
        public string TipoAnualidad { get; set; }

        [Required, MaxLength(10), Column(TypeName = "VARCHAR")]
        public string TipoAnualidadId { get; set; }

        public Guid ComboId { get; set; }

        public virtual List<AnualidadVariableEvaluada> VariablesEvaluadas { get; set; }

        #endregion Public Properties
    }
}