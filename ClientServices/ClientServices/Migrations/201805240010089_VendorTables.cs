namespace ClientServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientVendorJunctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        ClientVendorRelationshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ClientVendorRelationships", t => t.ClientVendorRelationshipId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.VendorId)
                .Index(t => t.ClientVendorRelationshipId);
            
            CreateTable(
                "dbo.ClientVendorRelationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationshipDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        StateId = c.Int(nullable: false),
                        ZipCode = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        FaxNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.VendorContactPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Extension = c.Int(nullable: false),
                        ContactTypeId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.ContactTypeId)
                .Index(t => t.PositionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorContactPersons", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.VendorContactPersons", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.VendorContactPersons", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.Vendors", "StateId", "dbo.States");
            DropForeignKey("dbo.ClientVendorJunctions", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.ClientVendorJunctions", "ClientVendorRelationshipId", "dbo.ClientVendorRelationships");
            DropForeignKey("dbo.ClientVendorJunctions", "ClientId", "dbo.Clients");
            DropIndex("dbo.VendorContactPersons", new[] { "PositionId" });
            DropIndex("dbo.VendorContactPersons", new[] { "ContactTypeId" });
            DropIndex("dbo.VendorContactPersons", new[] { "VendorId" });
            DropIndex("dbo.Vendors", new[] { "StateId" });
            DropIndex("dbo.ClientVendorJunctions", new[] { "ClientVendorRelationshipId" });
            DropIndex("dbo.ClientVendorJunctions", new[] { "VendorId" });
            DropIndex("dbo.ClientVendorJunctions", new[] { "ClientId" });
            DropTable("dbo.VendorContactPersons");
            DropTable("dbo.Vendors");
            DropTable("dbo.ClientVendorRelationships");
            DropTable("dbo.ClientVendorJunctions");
        }
    }
}
