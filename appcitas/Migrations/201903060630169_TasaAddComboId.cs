namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TasaAddComboId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGRC_Tasa", "ComboId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SGRC_Tasa", "ComboId");
        }
    }
}
