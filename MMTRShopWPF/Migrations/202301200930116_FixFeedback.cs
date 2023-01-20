namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFeedback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Feedbacks", new[] { "ProductID" });
            DropIndex("dbo.Feedbacks", new[] { "Client_Id" });
            DropColumn("dbo.Feedbacks", "ClientID");
            RenameColumn(table: "dbo.Feedbacks", name: "Client_Id", newName: "ClientId");
            AlterColumn("dbo.Feedbacks", "ClientId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Feedbacks", "ClientId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Feedbacks", "ProductId");
            CreateIndex("dbo.Feedbacks", "ClientId");
            AddForeignKey("dbo.Feedbacks", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "ClientId", "dbo.Clients");
            DropIndex("dbo.Feedbacks", new[] { "ClientId" });
            DropIndex("dbo.Feedbacks", new[] { "ProductId" });
            AlterColumn("dbo.Feedbacks", "ClientId", c => c.Guid());
            AlterColumn("dbo.Feedbacks", "ClientId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Feedbacks", name: "ClientId", newName: "Client_Id");
            AddColumn("dbo.Feedbacks", "ClientID", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "Client_Id");
            CreateIndex("dbo.Feedbacks", "ProductID");
            AddForeignKey("dbo.Feedbacks", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
