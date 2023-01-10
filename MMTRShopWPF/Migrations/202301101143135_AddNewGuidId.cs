namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewGuidId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Id2", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "CategoryId2", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "BrandId2", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "BrandId2");
            DropColumn("dbo.Products", "CategoryId2");
            DropColumn("dbo.Products", "Id2");
        }
    }
}
