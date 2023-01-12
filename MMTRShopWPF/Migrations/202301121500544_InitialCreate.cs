namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Int(nullable: false),
                        Photo = c.String(),
                        CountInStarage = c.Int(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        BrandId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ClientId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        ProductCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Emain = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ProductID = c.Guid(nullable: false),
                        Comment = c.String(),
                        Rating = c.Byte(nullable: false),
                        ClientID = c.Int(nullable: false),
                        Client_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CartId = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DateOrder = c.DateTime(nullable: false),
                        DateDelivery = c.DateTime(nullable: false),
                        StatusID = c.Int(nullable: false),
                        Status_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ClientId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operators", "UserId", "dbo.Users");
            DropForeignKey("dbo.Favourites", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Favourites", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.CartOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.CartOrders", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Feedbacks", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Carts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropIndex("dbo.Operators", new[] { "UserId" });
            DropIndex("dbo.Favourites", new[] { "ProductId" });
            DropIndex("dbo.Favourites", new[] { "ClientId" });
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropIndex("dbo.CartOrders", new[] { "OrderId" });
            DropIndex("dbo.CartOrders", new[] { "CartId" });
            DropIndex("dbo.Feedbacks", new[] { "Client_Id" });
            DropIndex("dbo.Feedbacks", new[] { "ProductID" });
            DropIndex("dbo.Clients", new[] { "UserId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropIndex("dbo.Carts", new[] { "ClientId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Admins", new[] { "UserId" });
            DropTable("dbo.Operators");
            DropTable("dbo.Favourites");
            DropTable("dbo.Status");
            DropTable("dbo.Orders");
            DropTable("dbo.CartOrders");
            DropTable("dbo.Categories");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Clients");
            DropTable("dbo.Carts");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
        }
    }
}
