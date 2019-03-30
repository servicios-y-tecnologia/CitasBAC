namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tasas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SGRC_ResultadosDeTasa",
                c => new
                    {
                        ItemDeReclamoId = c.String(nullable: false, maxLength: 128),
                        TasaId = c.Guid(nullable: false),
                        ReclamoId = c.String(),
                        ItemDeReclamoDescripcion = c.String(),
                        ResultadoAceptado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ItemDeReclamoId)
                .ForeignKey("dbo.SGRC_Tasa", t => t.TasaId, cascadeDelete: true)
                .Index(t => t.TasaId);
            
            CreateTable(
                "dbo.SGRC_Tasa",
                c => new
                    {
                        TasaId = c.Guid(nullable: false, identity: true),
                        NumeroCuenta = c.String(nullable: false, maxLength: 50),
                        CIF = c.String(nullable: false, maxLength: 25),
                        Fecha = c.DateTime(nullable: false),
                        Familia = c.String(nullable: false, maxLength: 50),
                        Segmento = c.String(nullable: false, maxLength: 100),
                        SegementoId = c.String(nullable: false, maxLength: 10, unicode: false),
                        Marca = c.String(nullable: false, maxLength: 50),
                        MarcaId = c.String(nullable: false, maxLength: 10, unicode: false),
                        TasaAnualizadaActual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaDelCambio = c.DateTime(nullable: false),
                        SaldoActual = c.Decimal(nullable: false, storeType: "money"),
                        Limite = c.Decimal(nullable: false, storeType: "money"),
                        Observacion = c.String(),
                        ResultadoAceptadoPorCliente = c.Boolean(nullable: false),
                        CreadoPorUsuario = c.String(),
                        CanalOAgencia = c.String(),
                        Flujo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TasaId);
            
            CreateTable(
                "dbo.SGRC_VariablesEvaluadasDeTasas",
                c => new
                    {
                        TasaId = c.Guid(nullable: false),
                        VariableDeItemId = c.Guid(nullable: false),
                        VariableCodigo = c.String(maxLength: 128),
                        VariableNombre = c.String(),
                        ReclamoId = c.String(),
                        ItemDeReclamoId = c.String(),
                        ItemDeReclamoNombre = c.String(),
                        CondicionLogica = c.String(),
                        ValorActual = c.String(),
                        ValorAEvaluar = c.String(),
                        EvaluacionCondicion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.TasaId, t.VariableDeItemId })
                .ForeignKey("dbo.SGRC_Tasa", t => t.TasaId, cascadeDelete: true)
                .ForeignKey("dbo.SGRC_Variables", t => t.VariableCodigo)
                .Index(t => t.TasaId)
                .Index(t => t.VariableCodigo);
            
            AddColumn("dbo.SGRC_Anualidades", "ResultadoAceptadoPorCliente", c => c.Boolean(nullable: false));
            AddColumn("dbo.SGRC_Anualidades", "CreadoPorUsuario", c => c.String());
            AddColumn("dbo.SGRC_Anualidades", "CanalOAgencia", c => c.String());
            AddColumn("dbo.SGRC_Anualidades", "Flujo", c => c.Int(nullable: false));
            AddColumn("dbo.SGRC_Reversion", "ResultadoAceptadoPorCliente", c => c.Boolean(nullable: false));
            AddColumn("dbo.SGRC_Reversion", "CreadoPorUsuario", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "CanalOAgencia", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "Flujo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SGRC_ResultadosDeTasa", "TasaId", "dbo.SGRC_Tasa");
            DropForeignKey("dbo.SGRC_VariablesEvaluadasDeTasas", "VariableCodigo", "dbo.SGRC_Variables");
            DropForeignKey("dbo.SGRC_VariablesEvaluadasDeTasas", "TasaId", "dbo.SGRC_Tasa");
            DropIndex("dbo.SGRC_VariablesEvaluadasDeTasas", new[] { "VariableCodigo" });
            DropIndex("dbo.SGRC_VariablesEvaluadasDeTasas", new[] { "TasaId" });
            DropIndex("dbo.SGRC_ResultadosDeTasa", new[] { "TasaId" });
            DropColumn("dbo.SGRC_Reversion", "Flujo");
            DropColumn("dbo.SGRC_Reversion", "CanalOAgencia");
            DropColumn("dbo.SGRC_Reversion", "CreadoPorUsuario");
            DropColumn("dbo.SGRC_Reversion", "ResultadoAceptadoPorCliente");
            DropColumn("dbo.SGRC_Anualidades", "Flujo");
            DropColumn("dbo.SGRC_Anualidades", "CanalOAgencia");
            DropColumn("dbo.SGRC_Anualidades", "CreadoPorUsuario");
            DropColumn("dbo.SGRC_Anualidades", "ResultadoAceptadoPorCliente");
            DropTable("dbo.SGRC_VariablesEvaluadasDeTasas");
            DropTable("dbo.SGRC_Tasa");
            DropTable("dbo.SGRC_ResultadosDeTasa");
        }
    }
}
