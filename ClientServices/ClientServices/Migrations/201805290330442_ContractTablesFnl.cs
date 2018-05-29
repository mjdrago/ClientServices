namespace ClientServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContractTablesFnl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractFormularyJunctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractInfoId = c.Int(nullable: false),
                        FormularyTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractInfoes", t => t.ContractInfoId, cascadeDelete: true)
                .ForeignKey("dbo.FormularyTypes", t => t.FormularyTypeId, cascadeDelete: true)
                .Index(t => t.ContractInfoId)
                .Index(t => t.FormularyTypeId);
            
            CreateTable(
                "dbo.ContractInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ContractEffectiveDate = c.DateTime(nullable: false),
                        BenefitRenewalMonth = c.Int(nullable: false),
                        ContractLength = c.Int(nullable: false),
                        GrandfatherStatus = c.Boolean(nullable: false),
                        ERISAStatus = c.Boolean(nullable: false),
                        TaxExempt = c.Boolean(nullable: false),
                        PricingTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.PricingTypes", t => t.PricingTypeId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.PricingTypeId);
            
            CreateTable(
                "dbo.PricingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PricingTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractProgramJunctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractInfoId = c.Int(nullable: false),
                        ProgramTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractInfoes", t => t.ContractInfoId, cascadeDelete: true)
                .ForeignKey("dbo.ProgramTypes", t => t.ProgramTypeId, cascadeDelete: true)
                .Index(t => t.ContractInfoId)
                .Index(t => t.ProgramTypeId);
            
            CreateTable(
                "dbo.ProgramTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormularyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormularyTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractFormularyJunctions", "FormularyTypeId", "dbo.FormularyTypes");
            DropForeignKey("dbo.ContractProgramJunctions", "ProgramTypeId", "dbo.ProgramTypes");
            DropForeignKey("dbo.ContractProgramJunctions", "ContractInfoId", "dbo.ContractInfoes");
            DropForeignKey("dbo.ContractInfoes", "PricingTypeId", "dbo.PricingTypes");
            DropForeignKey("dbo.ContractFormularyJunctions", "ContractInfoId", "dbo.ContractInfoes");
            DropForeignKey("dbo.ContractInfoes", "ClientId", "dbo.Clients");
            DropIndex("dbo.ContractProgramJunctions", new[] { "ProgramTypeId" });
            DropIndex("dbo.ContractProgramJunctions", new[] { "ContractInfoId" });
            DropIndex("dbo.ContractInfoes", new[] { "PricingTypeId" });
            DropIndex("dbo.ContractInfoes", new[] { "ClientId" });
            DropIndex("dbo.ContractFormularyJunctions", new[] { "FormularyTypeId" });
            DropIndex("dbo.ContractFormularyJunctions", new[] { "ContractInfoId" });
            DropTable("dbo.FormularyTypes");
            DropTable("dbo.ProgramTypes");
            DropTable("dbo.ContractProgramJunctions");
            DropTable("dbo.PricingTypes");
            DropTable("dbo.ContractInfoes");
            DropTable("dbo.ContractFormularyJunctions");
        }
    }
}
