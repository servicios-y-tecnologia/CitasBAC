namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthTipoReversion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_1", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_2", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_3", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_4", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_5", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_6", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_6", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_5", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_4", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_3", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_2", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.SGRC_Reversion", "TipoReversionId_1", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
