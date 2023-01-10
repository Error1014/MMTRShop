namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameVariables : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Admins", new[] { "ID" });
            DropIndex("dbo.Carts", new[] { "UserID" });
            DropIndex("dbo.Carts", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            AddColumn("dbo.Carts", "ProductCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Discount", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "Id");
            CreateIndex("dbo.Carts", "UserId");
            CreateIndex("dbo.Carts", "ProductId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "BrandId");
            DropColumn("dbo.Carts", "ValueProduct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "ValueProduct", c => c.Int(nullable: false));
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropIndex("dbo.Admins", new[] { "Id" });
            AlterColumn("dbo.Products", "Discount", c => c.Single(nullable: false));
            DropColumn("dbo.Carts", "ProductCount");
            CreateIndex("dbo.Products", "BrandID");
            CreateIndex("dbo.Products", "CategoryID");
            CreateIndex("dbo.Carts", "ProductID");
            CreateIndex("dbo.Carts", "UserID");
            CreateIndex("dbo.Admins", "ID");
        }
    }
}
