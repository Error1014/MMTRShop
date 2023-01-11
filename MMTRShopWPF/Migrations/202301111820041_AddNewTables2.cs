namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTables2 : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.CartOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.CartOrders", "CartId", "dbo.Carts");
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropIndex("dbo.CartOrders", new[] { "OrderId" });
            DropIndex("dbo.CartOrders", new[] { "CartId" });
            DropTable("dbo.Status");
            DropTable("dbo.Orders");
            DropTable("dbo.CartOrders");
        }
    }
}
