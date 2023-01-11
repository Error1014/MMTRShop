namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Operators", "User_Id", "dbo.Users");
            DropIndex("dbo.Operators", new[] { "User_Id" });
            RenameColumn(table: "dbo.Operators", name: "User_Id", newName: "UserId");
            DropPrimaryKey("dbo.Operators");
            AlterColumn("dbo.Operators", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Operators", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Operators", "Id");
            CreateIndex("dbo.Operators", "UserId");
            AddForeignKey("dbo.Operators", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operators", "UserId", "dbo.Users");
            DropIndex("dbo.Operators", new[] { "UserId" });
            DropPrimaryKey("dbo.Operators");
            AlterColumn("dbo.Operators", "UserId", c => c.Guid());
            AlterColumn("dbo.Operators", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Operators", "Id");
            RenameColumn(table: "dbo.Operators", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Operators", "User_Id");
            AddForeignKey("dbo.Operators", "User_Id", "dbo.Users", "Id");
        }
    }
}
