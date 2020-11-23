namespace BloodBank_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BBMSystems",
                c => new
                    {
                        BBMSystemId = c.Int(nullable: false, identity: true),
                        BBMSName = c.String(),
                        BloodSampleId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        DonorId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BBMSystemId)
                .ForeignKey("dbo.BloodInventoryManagers", t => t.ManagerId, cascadeDelete: true)
                .ForeignKey("dbo.BloodRecipients", t => t.RecipientId, cascadeDelete: true)
                .ForeignKey("dbo.BloodSamples", t => t.BloodSampleId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Donors", t => t.DonorId, cascadeDelete: true)
                .Index(t => t.BloodSampleId)
                .Index(t => t.ManagerId)
                .Index(t => t.RecipientId)
                .Index(t => t.DonorId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.BloodInventoryManagers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BloodSampleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerId)
                .ForeignKey("dbo.BloodSamples", t => t.BloodSampleId, cascadeDelete: false)
                .Index(t => t.BloodSampleId);
            
            CreateTable(
                "dbo.BloodSamples",
                c => new
                    {
                        BloodSampleId = c.Int(nullable: false, identity: true),
                        BloodGroups = c.Int(nullable: false),
                        BloodQuentity = c.Int(nullable: false),
                        DonorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BloodSampleId)
                .ForeignKey("dbo.Donors", t => t.DonorId, cascadeDelete: false)
                .Index(t => t.DonorId);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        DonorId = c.Int(nullable: false, identity: true),
                        DonorName = c.String(nullable: false, maxLength: 20),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        ContactNo = c.String(nullable: false),
                        DonateDate = c.DateTime(nullable: false),
                        QuentityOfBlood = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DonorId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.BloodRecipients",
                c => new
                    {
                        RecipientId = c.Int(nullable: false, identity: true),
                        RecipientName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        ContactNo = c.String(nullable: false),
                        DonorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipientId)
                .ForeignKey("dbo.Donors", t => t.DonorId, cascadeDelete: false)
                .Index(t => t.DonorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BBMSystems", "DonorId", "dbo.Donors");
            DropForeignKey("dbo.BBMSystems", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.BBMSystems", "BloodSampleId", "dbo.BloodSamples");
            DropForeignKey("dbo.BBMSystems", "RecipientId", "dbo.BloodRecipients");
            DropForeignKey("dbo.BloodRecipients", "DonorId", "dbo.Donors");
            DropForeignKey("dbo.BBMSystems", "ManagerId", "dbo.BloodInventoryManagers");
            DropForeignKey("dbo.BloodInventoryManagers", "BloodSampleId", "dbo.BloodSamples");
            DropForeignKey("dbo.BloodSamples", "DonorId", "dbo.Donors");
            DropForeignKey("dbo.Donors", "DistrictId", "dbo.Districts");
            DropIndex("dbo.BloodRecipients", new[] { "DonorId" });
            DropIndex("dbo.Donors", new[] { "DistrictId" });
            DropIndex("dbo.BloodSamples", new[] { "DonorId" });
            DropIndex("dbo.BloodInventoryManagers", new[] { "BloodSampleId" });
            DropIndex("dbo.BBMSystems", new[] { "DistrictId" });
            DropIndex("dbo.BBMSystems", new[] { "DonorId" });
            DropIndex("dbo.BBMSystems", new[] { "RecipientId" });
            DropIndex("dbo.BBMSystems", new[] { "ManagerId" });
            DropIndex("dbo.BBMSystems", new[] { "BloodSampleId" });
            DropTable("dbo.BloodRecipients");
            DropTable("dbo.Districts");
            DropTable("dbo.Donors");
            DropTable("dbo.BloodSamples");
            DropTable("dbo.BloodInventoryManagers");
            DropTable("dbo.BBMSystems");
        }
    }
}
