namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropColumn("dbo.Orders", "StatusID");
            RenameColumn(table: "dbo.Orders", name: "Status_Id", newName: "StatusId");
            AddColumn("dbo.BankCards", "Month", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "StatusId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "StatusId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Orders", "StatusId");
            AddForeignKey("dbo.Orders", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropColumn("dbo.BankCards", "Mont");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankCards", "Mont", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "StatusId", "dbo.Status");
            DropIndex("dbo.Orders", new[] { "StatusId" });
            AlterColumn("dbo.Orders", "StatusId", c => c.Guid());
            AlterColumn("dbo.Orders", "StatusId", c => c.Int(nullable: false));
            DropColumn("dbo.BankCards", "Month");
            RenameColumn(table: "dbo.Orders", name: "StatusId", newName: "Status_Id");
            AddColumn("dbo.Orders", "StatusID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Status_Id");
            AddForeignKey("dbo.Orders", "Status_Id", "dbo.Status", "Id");
        }
    }
}
