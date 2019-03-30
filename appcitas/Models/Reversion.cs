using appcitas.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appcitas.Models
{
    public class Reversion
    {
        #region Public Properties

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

        [Display(Name = "Fecha de Cargo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCargo_1 { get; set; }

        [Display(Name = "Fecha de Cargo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCargo_2 { get; set; }

        [Display(Name = "Fecha de Cargo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCargo_3 { get; set; }

        [Display(Name = "Fecha de Cargo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCargo_4 { get; set; }

        [Display(Name = "Fecha de Cargo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCargo_5 { get; set; }

        [Display(Name = "Fecha de Cargo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCargo_6 { get; set; }

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

        [Display(Name = "Monto")]
        [DataType(DataType.Currency)]
        public decimal Monto_1 { get; set; }

        [Display(Name = "Monto")]
        [DataType(DataType.Currency)]
        public decimal Monto_2 { get; set; }

        [Display(Name = "Monto")]
        [DataType(DataType.Currency)]
        public decimal Monto_3 { get; set; }

        [Display(Name = "Monto")]
        [DataType(DataType.Currency)]
        public decimal Monto_4 { get; set; }

        [Display(Name = "Monto")]
        [DataType(DataType.Currency)]
        public decimal Monto_5 { get; set; }

        [Display(Name = "Monto")]
        [DataType(DataType.Currency)]
        public decimal Monto_6 { get; set; }

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

        public virtual List<ResultadoReversion> ResultadosDeReversion { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReversionId { get; set; }

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

        public string TipoReversion_1 { get; set; }

        public string TipoReversion_2 { get; set; }

        public string TipoReversion_3 { get; set; }

        public string TipoReversion_4 { get; set; }

        public string TipoReversion_5 { get; set; }

        public string TipoReversion_6 { get; set; }

        [Display(Name = "Tipo de Reversión")]
        [MaxLength(30), Column(TypeName = "VARCHAR")]
        public string TipoReversionId_1 { get; set; }

        [Display(Name = "Tipo de Reversión")]
        [MaxLength(30), Column(TypeName = "VARCHAR")]
        public string TipoReversionId_2 { get; set; }

        [Display(Name = "Tipo de Reversión")]
        [MaxLength(30), Column(TypeName = "VARCHAR")]
        public string TipoReversionId_3 { get; set; }

        [Display(Name = "Tipo de Reversión")]
        [MaxLength(30), Column(TypeName = "VARCHAR")]
        public string TipoReversionId_4 { get; set; }

        [Display(Name = "Tipo de Reversión")]
        [MaxLength(30), Column(TypeName = "VARCHAR")]
        public string TipoReversionId_5 { get; set; }

        [Display(Name = "Tipo de Reversión")]
        [MaxLength(30), Column(TypeName = "VARCHAR")]
        public string TipoReversionId_6 { get; set; }

        public virtual List<VariableReversion> VariablesEvaluadas { get; set; }


        public Guid ComboId { get; set; }
        #endregion Public Properties
    }
}