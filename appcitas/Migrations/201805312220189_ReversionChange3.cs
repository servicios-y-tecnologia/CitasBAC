namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReversionChange3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SGRC_ResultadosDeReversion",
                c => new
                    {
                        ResultadoReversionId = c.Int(nullable: false, identity: true),
                        ReversionId = c.Guid(nullable: false),
                        CargoAReversar = c.Int(nullable: false),
                        ResultadoReversionDescripcion = c.String(),
                        ResultadoReversionAceptada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ResultadoReversionId)
                .ForeignKey("dbo.SGRC_Reversion", t => t.ReversionId, cascadeDelete: true)
                .Index(t => t.ReversionId);
            
            CreateTable(
                "dbo.SGRC_VariablesEvaluadasDeRversion",
                c => new
                    {
                        ReversionId = c.Guid(nullable: false),
                        VariableDeItemId = c.Guid(nullable: false),
                        CargoNumero = c.Int(nullable: false),
                        VariableCodigo = c.String(maxLength: 128),
                        CondicionLogica = c.String(),
                        ValorAEvaluar = c.String(),
                        ValorActual = c.String(),
                        EvaluacionCondicion = c.Boolean(nullable: false),
                        ReclamoId = c.String(),
                        ItemDeReclamoId = c.String(),
                        ItemDeReclamoNombre = c.String(),
                        VariableNombre = c.String(),
                    })
                .PrimaryKey(t => new { t.ReversionId, t.VariableDeItemId, t.CargoNumero })
                .ForeignKey("dbo.SGRC_Reversion", t => t.ReversionId, cascadeDelete: true)
                .ForeignKey("dbo.SGRC_Variables", t => t.VariableCodigo)
                .Index(t => t.ReversionId)
                .Index(t => t.VariableCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SGRC_VariablesEvaluadasDeRversion", "VariableCodigo", "dbo.SGRC_Variables");
            DropForeignKey("dbo.SGRC_VariablesEvaluadasDeRversion", "ReversionId", "dbo.SGRC_Reversion");
            DropForeignKey("dbo.SGRC_ResultadosDeReversion", "ReversionId", "dbo.SGRC_Reversion");
            DropIndex("dbo.SGRC_VariablesEvaluadasDeRversion", new[] { "VariableCodigo" });
            DropIndex("dbo.SGRC_VariablesEvaluadasDeRversion", new[] { "ReversionId" });
            DropIndex("dbo.SGRC_ResultadosDeReversion", new[] { "ReversionId" });
            DropTable("dbo.SGRC_VariablesEvaluadasDeRversion");
            DropTable("dbo.SGRC_ResultadosDeReversion");
        }
    }
}
