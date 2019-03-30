namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarCitaIdAMotor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGRC_Anualidades", "CitaId", c => c.Int(nullable: false));
            AddColumn("dbo.SGRC_Reversion", "CitaId", c => c.Int(nullable: false));
            AddColumn("dbo.SGRC_Tasa", "Citaid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SGRC_Tasa", "Citaid");
            DropColumn("dbo.SGRC_Reversion", "CitaId");
            DropColumn("dbo.SGRC_Anualidades", "CitaId");
        }
    }
}
