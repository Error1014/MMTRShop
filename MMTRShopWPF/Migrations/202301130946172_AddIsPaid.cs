namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsPaid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsPaid", c => c.Boolean(nullable: false));
            DropColumn("dbo.BankCards", "IsPaid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankCards", "IsPaid", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "IsPaid");
        }
    }
}
