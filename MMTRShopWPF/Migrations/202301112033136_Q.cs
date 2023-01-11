namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Q : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operators", "UserId", "dbo.Users");
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
