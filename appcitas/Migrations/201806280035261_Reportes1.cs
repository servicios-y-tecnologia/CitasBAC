namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reportes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGRC_Anualidades", "Buro", c => c.Boolean(nullable: false));
            AddColumn("dbo.SGRC_Reversion", "Buro", c => c.Boolean(nullable: false));
            AddColumn("dbo.SGRC_Tasa", "Buro", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SGRC_Tasa", "Buro");
            DropColumn("dbo.SGRC_Reversion", "Buro");
            DropColumn("dbo.SGRC_Anualidades", "Buro");
        }
    }
}
