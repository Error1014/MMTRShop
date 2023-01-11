namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropForeignKey("dbo.Carts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Operators", "UserId", "dbo.Users");
            DropForeignKey("dbo.Carts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Admins");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Carts");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Brands");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Operators");
            AlterColumn("dbo.Admins", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AlterColumn("dbo.Carts", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AlterColumn("dbo.Clients", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AlterColumn("dbo.Brands", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AlterColumn("dbo.Categories", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AlterColumn("dbo.Operators", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newid()"));
            AddPrimaryKey("dbo.Admins", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Carts", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Brands", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Operators", "Id");
            AddForeignKey("dbo.Clients", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Admins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Operators", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Carts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Operators", "UserId", "dbo.Users");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Carts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Operators");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Brands");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Carts");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Admins");
            AlterColumn("dbo.Operators", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Brands", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Clients", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Carts", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Admins", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Operators", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Brands", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.Carts", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Admins", "Id");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Operators", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Clients", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
