namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Discount", c => c.Single(nullable: false));
            DropColumn("dbo.Products", "Diccount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Diccount", c => c.Single(nullable: false));
            DropColumn("dbo.Products", "Discount");
        }
    }
}
