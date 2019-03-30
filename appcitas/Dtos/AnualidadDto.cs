﻿using appcitas.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcitas.Dtos
{
    public class AnualidadDto
    {
        #region Public Properties

        public int Accion { get; set; }
        public Guid AnualidadId { get; set; }
        public Guid ComboId { get; set; }
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Fecha del Cargo")]
        [DataType(DataType.Date)]
        [DateValidation(ErrorMessage = "La fecha no puede ser mayor que la fecha actual")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeCargo { get; set; }

        public FlowUtilizado Flujo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Identidad")]
        public string Identidad { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Limite")]
        [DataType(DataType.Currency)]
        public decimal Limite { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Marca")]
        [StringLength(50, ErrorMessage = "Este campo no puede ser mas larga de 50 caracteres")]
        public string Marca { get; set; }

        [Required, MaxLength(10), Column(TypeName = "VARCHAR")]
        public string MarcaId { get; set; }

        public string Mensaje { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Monto")]
        [DataType(DataType.Currency)]
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
       

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Saldo Actual")]
        [DataType(DataType.Currency)]
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

        [Display(Name = "Tipo de Anualidad")]
        [Required, MaxLength(10), Column(TypeName = "VARCHAR")]
        public string TipoAnualidadId { get; set; }

        public virtual List<AnualidadVariableEvaluadaDto> VariablesEvaluadas { get; set; }

        public List<AnualidadResultadoObtenidoDto> Resultados { get; set; }

        #endregion Public Properties
    }
}