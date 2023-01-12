namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavouritesTable : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Favourites", "ClientId", "dbo.Clients");
            DropIndex("dbo.Favourites", new[] { "ProductId" });
            DropIndex("dbo.Favourites", new[] { "ClientId" });
            DropTable("dbo.Favourites");
        }
    }
}
