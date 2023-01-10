namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCart : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Korzines", newName: "Carts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Carts", newName: "Korzines");
        }
    }
}
