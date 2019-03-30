namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tasas1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGRC_Tasa", "NumeroTarjeta", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SGRC_Tasa", "NumeroTarjeta");
        }
    }
}
