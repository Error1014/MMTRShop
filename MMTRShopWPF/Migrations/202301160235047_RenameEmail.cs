namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Email", c => c.String());
            DropColumn("dbo.Clients", "Emain");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Emain", c => c.String());
            DropColumn("dbo.Clients", "Email");
        }
    }
}
