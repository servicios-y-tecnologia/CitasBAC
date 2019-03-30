namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGRC_Anualidades", "Identidad", c => c.String(nullable: false));
            AddColumn("dbo.SGRC_Reversion", "Identidad", c => c.String(nullable: false));
            AddColumn("dbo.SGRC_Tasa", "Identidad", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SGRC_Tasa", "Identidad");
            DropColumn("dbo.SGRC_Reversion", "Identidad");
            DropColumn("dbo.SGRC_Anualidades", "Identidad");
        }
    }
}
