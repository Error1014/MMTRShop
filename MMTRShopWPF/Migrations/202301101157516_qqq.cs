namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qqq : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "Id2");
            DropColumn("dbo.Users", "Id2");
            DropColumn("dbo.Carts", "Id2");
            DropColumn("dbo.Carts", "UserId2");
            DropColumn("dbo.Carts", "ProductId2");
            DropColumn("dbo.Products", "Id2");
            DropColumn("dbo.Products", "CategoryId2");
            DropColumn("dbo.Products", "BrandId2");
            DropColumn("dbo.Brands", "Id2");
            DropColumn("dbo.Categories", "Id2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Id2", c => c.Guid(nullable: false));
            AddColumn("dbo.Brands", "Id2", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "BrandId2", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "CategoryId2", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "Id2", c => c.Guid(nullable: false));
            AddColumn("dbo.Carts", "ProductId2", c => c.Guid(nullable: false));
            AddColumn("dbo.Carts", "UserId2", c => c.Guid(nullable: false));
            AddColumn("dbo.Carts", "Id2", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "Id2", c => c.Guid(nullable: false));
            AddColumn("dbo.Admins", "Id2", c => c.Guid(nullable: false));
        }
    }
}
