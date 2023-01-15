namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartOrders", "CartId", "dbo.Carts");
            DropForeignKey("dbo.CartOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropForeignKey("dbo.Operators", "UserId", "dbo.Users");
            DropForeignKey("dbo.BankCards", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Carts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Feedbacks", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Favourites", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Favourites", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Orders", "StatusId", "dbo.Status");
            DropIndex("dbo.CartOrders", new[] { "CartId" });
            DropIndex("dbo.CartOrders", new[] { "OrderId" });
            DropPrimaryKey("dbo.Admins");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.BankCards");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Carts");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Brands");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Feedbacks");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Status");
            DropPrimaryKey("dbo.Favourites");
            DropPrimaryKey("dbo.Operators");
            CreateTable(
                "dbo.OrderContents",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        OrderId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        CountProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Orders", "ClientId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Admins", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.BankCards", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Clients", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Carts", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Brands", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Feedbacks", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Status", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Favourites", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Operators", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Admins", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.BankCards", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.Carts", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Brands", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Feedbacks", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            AddPrimaryKey("dbo.Status", "Id");
            AddPrimaryKey("dbo.Favourites", "Id");
            AddPrimaryKey("dbo.Operators", "Id");
            CreateIndex("dbo.Orders", "ClientId");
            AddForeignKey("dbo.Orders", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Operators", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BankCards", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Favourites", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Favourites", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropTable("dbo.CartOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CartId = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Orders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Favourites", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Favourites", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Feedbacks", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Carts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.BankCards", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Operators", "UserId", "dbo.Users");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderContents", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderContents", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropIndex("dbo.OrderContents", new[] { "ProductId" });
            DropIndex("dbo.OrderContents", new[] { "OrderId" });
            DropPrimaryKey("dbo.Operators");
            DropPrimaryKey("dbo.Favourites");
            DropPrimaryKey("dbo.Status");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Feedbacks");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Brands");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Carts");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.BankCards");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Admins");
            AlterColumn("dbo.Operators", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Favourites", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Status", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Orders", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Feedbacks", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Brands", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Carts", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Clients", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.BankCards", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Admins", "Id", c => c.Guid(nullable: false, identity: true));
            DropColumn("dbo.Orders", "ClientId");
            DropTable("dbo.OrderContents");
            AddPrimaryKey("dbo.Operators", "Id");
            AddPrimaryKey("dbo.Favourites", "Id");
            AddPrimaryKey("dbo.Status", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            AddPrimaryKey("dbo.Feedbacks", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Brands", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Carts", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.BankCards", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Admins", "Id");
            CreateIndex("dbo.CartOrders", "OrderId");
            CreateIndex("dbo.CartOrders", "CartId");
            AddForeignKey("dbo.Orders", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Favourites", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Favourites", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Carts", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BankCards", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Operators", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CartOrders", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CartOrders", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
    }
}
