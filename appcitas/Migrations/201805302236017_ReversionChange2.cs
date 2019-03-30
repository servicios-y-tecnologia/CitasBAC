namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReversionChange2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGRC_Reversion", "TipoReversion_1", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoReversion_2", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoReversion_3", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoReversion_4", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoReversion_5", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoReversion_6", c => c.String());
            DropColumn("dbo.SGRC_Reversion", "TipoeReversion_1");
            DropColumn("dbo.SGRC_Reversion", "TipoeReversion_2");
            DropColumn("dbo.SGRC_Reversion", "TipoeReversion_3");
            DropColumn("dbo.SGRC_Reversion", "TipoeReversion_4");
            DropColumn("dbo.SGRC_Reversion", "TipoeReversion_5");
            DropColumn("dbo.SGRC_Reversion", "TipoeReversion_6");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SGRC_Reversion", "TipoeReversion_6", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoeReversion_5", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoeReversion_4", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoeReversion_3", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoeReversion_2", c => c.String());
            AddColumn("dbo.SGRC_Reversion", "TipoeReversion_1", c => c.String());
            DropColumn("dbo.SGRC_Reversion", "TipoReversion_6");
            DropColumn("dbo.SGRC_Reversion", "TipoReversion_5");
            DropColumn("dbo.SGRC_Reversion", "TipoReversion_4");
            DropColumn("dbo.SGRC_Reversion", "TipoReversion_3");
            DropColumn("dbo.SGRC_Reversion", "TipoReversion_2");
            DropColumn("dbo.SGRC_Reversion", "TipoReversion_1");
        }
    }
}
