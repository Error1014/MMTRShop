namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class w : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "Title");
        }
    }
}
