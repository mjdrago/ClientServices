namespace ClientServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RatePeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractInfoId = c.Int(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractInfoes", t => t.ContractInfoId, cascadeDelete: true)
                .Index(t => t.ContractInfoId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RatePeriodId = c.Int(nullable: false),
                        RateTypeId = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                        DispensingFee = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RatePeriods", t => t.RatePeriodId, cascadeDelete: true)
                .ForeignKey("dbo.RateTypes", t => t.RateTypeId, cascadeDelete: true)
                .Index(t => t.RatePeriodId)
                .Index(t => t.RateTypeId);
            
            CreateTable(
                "dbo.RateTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RateLink = c.String(),
                        RateTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "RateTypeId", "dbo.RateTypes");
            DropForeignKey("dbo.Rates", "RatePeriodId", "dbo.RatePeriods");
            DropForeignKey("dbo.RatePeriods", "ContractInfoId", "dbo.ContractInfoes");
            DropIndex("dbo.Rates", new[] { "RateTypeId" });
            DropIndex("dbo.Rates", new[] { "RatePeriodId" });
            DropIndex("dbo.RatePeriods", new[] { "ContractInfoId" });
            DropTable("dbo.RateTypes");
            DropTable("dbo.Rates");
            DropTable("dbo.RatePeriods");
        }
    }
}
