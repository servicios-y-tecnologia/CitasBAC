namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReversionChange4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGRC_Reversion", "NumeroCuenta", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SGRC_Reversion", "NumeroCuenta");
        }
    }
}
