namespace ClientServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientContactPersons : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ClientAddresses", newName: "ClientContacts");
            CreateTable(
                "dbo.ClientContactPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Extension = c.Int(nullable: false),
                        ContactTypeId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ContactTypeId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ClientContacts", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ClientContacts", "FaxNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientContactPersons", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.ClientContactPersons", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.ClientContactPersons", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientContactPersons", new[] { "PositionId" });
            DropIndex("dbo.ClientContactPersons", new[] { "ContactTypeId" });
            DropIndex("dbo.ClientContactPersons", new[] { "ClientId" });
            DropColumn("dbo.ClientContacts", "FaxNumber");
            DropColumn("dbo.ClientContacts", "PhoneNumber");
            DropTable("dbo.Positions");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.ClientContactPersons");
            RenameTable(name: "dbo.ClientContacts", newName: "ClientAddresses");
        }
    }
}
