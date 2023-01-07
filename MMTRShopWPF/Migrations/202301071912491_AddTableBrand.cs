namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableBrand : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "BrandID", c => c.Int());
            CreateIndex("dbo.Products", "BrandID");
            AddForeignKey("dbo.Products", "BrandID", "dbo.Brands", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropColumn("dbo.Products", "BrandID");
            DropTable("dbo.Brands");
        }
    }
}
