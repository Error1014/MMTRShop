namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdIntToGuid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Admins", "Id", "dbo.Users");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Admins", new[] { "Id" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropPrimaryKey("dbo.Admins");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Carts");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Brands");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Admins", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Carts", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Carts", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Carts", "ProductId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "BrandId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Brands", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Admins", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Carts", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Brands", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            CreateIndex("dbo.Admins", "Id");
            CreateIndex("dbo.Carts", "UserId");
            CreateIndex("dbo.Carts", "ProductId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "BrandId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
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
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Admins", "Id", "dbo.Users");
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Brands");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Carts");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Admins");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Brands", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "BrandId", c => c.Int());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Carts", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Admins", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Brands", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Carts", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Admins", "Id");
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Carts", "ProductId");
            CreateIndex("dbo.Carts", "UserId");
            CreateIndex("dbo.Admins", "Id");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Carts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id");
        }
    }
}
