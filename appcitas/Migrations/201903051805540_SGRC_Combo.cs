namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SGRC_Combo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SGRC_Combo", "FechaCreacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SGRC_Combo", "FechaCreacion", c => c.String(nullable: false));
        }
    }
}
