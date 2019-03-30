using appcitas.Models;
using System.Data.Entity;

namespace appcitas.Context
{
    public class AppcitasContext : DbContext
    {
        #region Public Constructors

        public AppcitasContext() : base("name=AppcitasContext")
        {
        }

        #endregion Public Constructors



        #region Public Properties

        public DbSet<Anualidad> Anualidades { get; set; }
        public DbSet<Config> Configuraciones { get; set; }
        public DbSet<Emisores> DbSetEmisores { get; set; }
        public DbSet<Sucursales> dbSucursales { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<ConfigItem> ItemsDeConfiguracion { get; set; }
        public DbSet<ItemDeReclamo> ItemsDeReclamo { get; set; }
        public DbSet<Parametro> ParametrosDeFunciones { get; set; }
        public DbSet<Reclamo> Reclamos { get; set; }
        public DbSet<AnualidadResultadoObtenido> ResultadoObtenidosDeAnualidad { get; set; }
        public DbSet<Reversion> Reversiones { get; set; }
        public DbSet<TasaResultado> TasaResultados { get; set; }
        public DbSet<Tasa> Tasas { get; set; }
        public DbSet<TasaVariableEvaluada> TasasVariablesEvaluadas { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<VariableDeItem> VariablesDeItem { get; set; }
        public DbSet<AnualidadVariableEvaluada> VariablesEvaluadasDeAnualidad { get; set; }
        public DbSet<VariableReversion> VariablesEvaluadasDeReversion { get; set; }

        public DbSet<Combo> Combos { get; set; }

        #endregion Public Properties

        //public DbSet<Citas> CitasProgramadas { get; set; }



        #region Protected Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var vEntity = modelBuilder.Entity<Variable>();
            vEntity.ToTable("SGRC_Variables");

            var parametrosEntity = modelBuilder.Entity<Parametro>();
            parametrosEntity.ToTable("SGRC_Parametros");
            parametrosEntity.HasRequired(x => x.Tipo).WithMany()
                .HasForeignKey(x => new { x.ConfigID, x.TipoId })
                .WillCascadeOnDelete(false);

            var funcionEntity = modelBuilder.Entity<Funcion>();
            funcionEntity.ToTable("SGRC_Funciones");
            funcionEntity.HasRequired(f => f.TipoDeRetorno).WithMany()
                .HasForeignKey(f => new { f.ConfigId, f.FuncionTipoDeRetorno })
                .WillCascadeOnDelete(false);

            var configEntity = modelBuilder.Entity<Config>();
            configEntity.ToTable("SGRC_Config");
            configEntity.Property(x => x.Estado).HasColumnName("ConfigStatus");

            modelBuilder.Entity<ConfigItem>().ToTable("SGRC_ConfigItem");

            var reclamoEntity = modelBuilder.Entity<Reclamo>();
            reclamoEntity.ToTable("SGRC_Reclamos");

            var itemsDeReclamoEntity = modelBuilder.Entity<ItemDeReclamo>();
            itemsDeReclamoEntity.ToTable("SGRC_ItemsDeReclamos");
            itemsDeReclamoEntity.HasKey(x => new { x.ReclamoId, x.ItemDeReclamoId });
            itemsDeReclamoEntity.HasRequired(x => x.Reclamo).WithMany(r => r.ItemsDeReclamo)
                .HasForeignKey(x => x.ReclamoId);

            var variablesAEvaluarEntity = modelBuilder.Entity<VariableDeItem>();
            variablesAEvaluarEntity.ToTable("SGRC_VariablesDeItems");
            variablesAEvaluarEntity.HasRequired(x => x.ItemDeReclamo)
                .WithMany(i => i.VariablesAEvaluar)
                .HasForeignKey(x => new { x.ReclamoId, x.ItemDeReclamoId });

            var emisoresEnt = modelBuilder.Entity<Emisores>();
            emisoresEnt.ToTable("SGRC_Emisor");

            var anualidadEntity = modelBuilder.Entity<Anualidad>();
            anualidadEntity.ToTable("SGRC_Anualidades");

            var ComboEntity = modelBuilder.Entity<Combo>();
            ComboEntity.ToTable("SGRC_Combo");

            var variableAnualidadEntity = modelBuilder.Entity<AnualidadVariableEvaluada>();
            variableAnualidadEntity.ToTable("SGRC_VariablesEvaluadasDeAnualidad");
            variableAnualidadEntity.HasKey(x => new { x.AnualidadId, x.VariableDeItemId });
            variableAnualidadEntity.HasRequired(x => x.Anualidad).WithMany().HasForeignKey(x => x.AnualidadId);

            var resultadoAnualidadEntity = modelBuilder.Entity<AnualidadResultadoObtenido>();
            resultadoAnualidadEntity.ToTable("SGRC_ResultadosDeAnualidad");
            resultadoAnualidadEntity.HasKey(x => x.ItemDeReclamoId);
            resultadoAnualidadEntity.HasRequired(x => x.Anualidad).WithMany().HasForeignKey(x => x.AnualidadId);

            var tasaEntity = modelBuilder.Entity<Tasa>();
            tasaEntity.ToTable("SGRC_Tasa");

            var tasaVariablesEntity = modelBuilder.Entity<TasaVariableEvaluada>();
            tasaVariablesEntity.ToTable("SGRC_VariablesEvaluadasDeTasas");
            tasaVariablesEntity.HasKey(x => new { x.TasaId, x.VariableDeItemId });
            tasaVariablesEntity.HasRequired(x => x.Tasa).WithMany(t => t.VariablesEvaluadas).HasForeignKey(x => x.TasaId);

            var tasaResultadoEntity = modelBuilder.Entity<TasaResultado>();
            tasaResultadoEntity.ToTable("SGRC_ResultadosDeTasa");
            tasaResultadoEntity.HasKey(x => x.ItemDeReclamoId);
            tasaResultadoEntity.HasRequired(x => x.Tasa).WithMany(t => t.Resultados).HasForeignKey(x => x.TasaId);

            var reversionEntity = modelBuilder.Entity<Reversion>();
            reversionEntity.ToTable("SGRC_Reversion");

            var variableReversionEntity = modelBuilder.Entity<VariableReversion>();
            variableReversionEntity.ToTable("SGRC_VariablesEvaluadasDeRversion");
            variableReversionEntity.HasKey(x => new { x.ReversionId, x.VariableDeItemId, x.CargoNumero });
            variableReversionEntity.HasRequired(x => x.Reversion).WithMany(r => r.VariablesEvaluadas).HasForeignKey(x => x.ReversionId);

            var resultadoReversionEntity = modelBuilder.Entity<ResultadoReversion>();
            resultadoReversionEntity.ToTable("SGRC_ResultadosDeReversion");
            resultadoReversionEntity.HasRequired(x => x.Reversion).WithMany(r => r.ResultadosDeReversion).HasForeignKey(x => x.ReversionId);

            var sucursalesEntity = modelBuilder.Entity<Sucursales>();
            sucursalesEntity.ToTable("SGRC_Sucursal");

            //var citaEntity = modelBuilder.Entity<Citas>();
            //citaEntity.ToTable("SGRC_Cita");
        }

        #endregion Protected Methods
    }
}