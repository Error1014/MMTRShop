namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddountProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CountInStorage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CountInStorage", c => c.Int(nullable: false));
        }
    }
}
