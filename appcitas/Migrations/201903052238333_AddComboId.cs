namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComboId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGRC_Anualidades", "ComboId", c => c.Guid(nullable: false));
            AddColumn("dbo.SGRC_Reversion", "ComboId", c => c.Guid(nullable: false));
           // AddColumn("dbo.SGRC_Tasa", "ComboId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SGRC_Reversion", "ComboId");
            DropColumn("dbo.SGRC_Anualidades", "ComboId");
           // DropColumn("dbo.SGRC_Tasa", "ComboId");
        }
    }
}
