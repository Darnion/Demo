namespace Demo.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefectTypes",
                c => new
                    {
                        IdDefectType = c.Int(nullable: false, identity: true),
                        DefectTypeTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdDefectType);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        IdRequest = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                        DefectTypeId = c.Int(nullable: false),
                        EquipmentModel = c.String(nullable: false),
                        Description = c.String(),
                        ClientId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Comment = c.String(),
                        WorkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRequest)
                .ForeignKey("dbo.Users", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.WorkerId)
                .ForeignKey("dbo.DefectTypes", t => t.DefectTypeId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.EquipmentTypeId)
                .Index(t => t.DefectTypeId)
                .Index(t => t.ClientId)
                .Index(t => t.StatusId)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        IdRole = c.Int(nullable: false, identity: true),
                        RoleTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdRole);
            
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        IdEquipmentType = c.Int(nullable: false, identity: true),
                        EquipmentTypeTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdEquipmentType);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        IdReport = c.Int(nullable: false),
                        ReportContent = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdReport)
                .ForeignKey("dbo.Requests", t => t.IdReport)
                .Index(t => t.IdReport);
            
            CreateTable(
                "dbo.RequestSpares",
                c => new
                    {
                        IdRequestSpares = c.Int(nullable: false, identity: true),
                        SpareId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                        SparesCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRequestSpares)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .ForeignKey("dbo.Spares", t => t.SpareId, cascadeDelete: true)
                .Index(t => t.SpareId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Spares",
                c => new
                    {
                        IdSpare = c.Int(nullable: false, identity: true),
                        SpareTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdSpare);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        IdStatus = c.Int(nullable: false, identity: true),
                        StatusTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdStatus);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.RequestSpares", "SpareId", "dbo.Spares");
            DropForeignKey("dbo.RequestSpares", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Reports", "IdReport", "dbo.Requests");
            DropForeignKey("dbo.Requests", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.Requests", "DefectTypeId", "dbo.DefectTypes");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Requests", "WorkerId", "dbo.Users");
            DropForeignKey("dbo.Requests", "ClientId", "dbo.Users");
            DropIndex("dbo.RequestSpares", new[] { "RequestId" });
            DropIndex("dbo.RequestSpares", new[] { "SpareId" });
            DropIndex("dbo.Reports", new[] { "IdReport" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Requests", new[] { "WorkerId" });
            DropIndex("dbo.Requests", new[] { "StatusId" });
            DropIndex("dbo.Requests", new[] { "ClientId" });
            DropIndex("dbo.Requests", new[] { "DefectTypeId" });
            DropIndex("dbo.Requests", new[] { "EquipmentTypeId" });
            DropTable("dbo.Status");
            DropTable("dbo.Spares");
            DropTable("dbo.RequestSpares");
            DropTable("dbo.Reports");
            DropTable("dbo.EquipmentTypes");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Requests");
            DropTable("dbo.DefectTypes");
        }
    }
}
