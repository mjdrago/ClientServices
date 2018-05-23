namespace ClientServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationOfClients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        StateId = c.Int(nullable: false),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OriginalEffectiveDate = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(nullable: false),
                        RunOutNeeded = c.Boolean(nullable: false),
                        RunOutDate = c.DateTime(nullable: false),
                        ImproperTerminationNotice = c.Boolean(nullable: false),
                        TermReasonId = c.Int(nullable: false),
                        ClosedClientIndicator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TermReasons", t => t.TermReasonId, cascadeDelete: true)
                .Index(t => t.TermReasonId);
            
            CreateTable(
                "dbo.TermReasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TermReasonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        StateAbbreviation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientAddresses", "StateId", "dbo.States");
            DropForeignKey("dbo.ClientAddresses", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "TermReasonId", "dbo.TermReasons");
            DropIndex("dbo.Clients", new[] { "TermReasonId" });
            DropIndex("dbo.ClientAddresses", new[] { "StateId" });
            DropIndex("dbo.ClientAddresses", new[] { "ClientId" });
            DropTable("dbo.States");
            DropTable("dbo.TermReasons");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientAddresses");
        }
    }
}
