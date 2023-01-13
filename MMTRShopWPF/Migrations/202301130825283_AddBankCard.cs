namespace MMTRShopWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBankCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankCards",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Number = c.String(),
                        Name = c.String(),
                        Mont = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Code = c.String(),
                        ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankCards", "ClientId", "dbo.Clients");
            DropIndex("dbo.BankCards", new[] { "ClientId" });
            DropTable("dbo.BankCards");
        }
    }
}
