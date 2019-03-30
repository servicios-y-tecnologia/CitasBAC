namespace appcitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgroupvariableitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGRC_VariablesDeItems", "GroupVariable", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SGRC_VariablesDeItems", "GroupVariable");
        }
    }
}
