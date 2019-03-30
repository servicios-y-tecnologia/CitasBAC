namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReversionChange1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SGRC_Reversion",
                c => new
                    {
                        ReversionId = c.Guid(nullable: false, identity: true),
                        NumeroTarjeta = c.String(nullable: false, maxLength: 50),
                        CIF = c.String(nullable: false, maxLength: 25),
                        Fecha = c.DateTime(nullable: false),
                        Familia = c.String(nullable: false, maxLength: 50),
                        Segmento = c.String(nullable: false, maxLength: 100),
                        SegmentoId = c.String(nullable: false, maxLength: 10, unicode: false),
                        Marca = c.String(nullable: false, maxLength: 50),
                        MarcaId = c.String(nullable: false, maxLength: 10, unicode: false),
                        SaldoActual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Limite = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoReversionId_1 = c.String(maxLength: 10, unicode: false),
                        TipoeReversion_1 = c.String(),
                        Monto_1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCargo_1 = c.DateTime(nullable: false),
                        TipoReversionId_2 = c.String(maxLength: 10, unicode: false),
                        TipoeReversion_2 = c.String(),
                        Monto_2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCargo_2 = c.DateTime(nullable: false),
                        TipoReversionId_3 = c.String(maxLength: 10, unicode: false),
                        TipoeReversion_3 = c.String(),
                        Monto_3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCargo_3 = c.DateTime(nullable: false),
                        TipoReversionId_4 = c.String(maxLength: 10, unicode: false),
                        TipoeReversion_4 = c.String(),
                        Monto_4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCargo_4 = c.DateTime(nullable: false),
                        TipoReversionId_5 = c.String(maxLength: 10, unicode: false),
                        TipoeReversion_5 = c.String(),
                        Monto_5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCargo_5 = c.DateTime(nullable: false),
                        TipoReversionId_6 = c.String(maxLength: 10, unicode: false),
                        TipoeReversion_6 = c.String(),
                        Monto_6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCargo_6 = c.DateTime(nullable: false),
                        Observacion = c.String(),
                    })
                .PrimaryKey(t => t.ReversionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SGRC_Reversion");
        }
    }
}
