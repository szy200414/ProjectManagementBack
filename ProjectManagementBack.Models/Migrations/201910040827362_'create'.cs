namespace ProjectManagementBack.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annonces",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Priority = c.Int(nullable: false),
                        GroupId = c.Guid(nullable: false),
                        CreatePersonId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatePersonId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.GroupId)
                .Index(t => t.CreatePersonId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ImagePath = c.String(),
                        Tel = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GroupName = c.String(),
                        Desc = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MissionLists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ListName = c.String(),
                        ProjectId = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Desc = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        State = c.Int(nullable: false),
                        ScoreTot = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.MissionLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Desc = c.String(),
                        MissionId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Missions", t => t.MissionId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.MissionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Missions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MissionName = c.String(),
                        Desc = c.String(),
                        Priority = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        MissionListId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MissionLists", t => t.MissionListId)
                .Index(t => t.MissionListId);
            
            CreateTable(
                "dbo.MissionOwners",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MissionId = c.Guid(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Missions", t => t.MissionId)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.MissionId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.ProjectMembers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        Role = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.MemberId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.MemberId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        GroupId = c.Guid(nullable: false),
                        Position = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGroups", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.ProjectMembers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectMembers", "MemberId", "dbo.Users");
            DropForeignKey("dbo.MissionOwners", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.MissionOwners", "MissionId", "dbo.Missions");
            DropForeignKey("dbo.MissionLogs", "UserId", "dbo.Users");
            DropForeignKey("dbo.MissionLogs", "MissionId", "dbo.Missions");
            DropForeignKey("dbo.Missions", "MissionListId", "dbo.MissionLists");
            DropForeignKey("dbo.MissionLists", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Annonces", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Annonces", "CreatePersonId", "dbo.Users");
            DropIndex("dbo.UserGroups", new[] { "GroupId" });
            DropIndex("dbo.UserGroups", new[] { "UserId" });
            DropIndex("dbo.ProjectMembers", new[] { "ProjectId" });
            DropIndex("dbo.ProjectMembers", new[] { "MemberId" });
            DropIndex("dbo.MissionOwners", new[] { "OwnerId" });
            DropIndex("dbo.MissionOwners", new[] { "MissionId" });
            DropIndex("dbo.Missions", new[] { "MissionListId" });
            DropIndex("dbo.MissionLogs", new[] { "UserId" });
            DropIndex("dbo.MissionLogs", new[] { "MissionId" });
            DropIndex("dbo.Projects", new[] { "OwnerId" });
            DropIndex("dbo.MissionLists", new[] { "ProjectId" });
            DropIndex("dbo.Annonces", new[] { "CreatePersonId" });
            DropIndex("dbo.Annonces", new[] { "GroupId" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.ProjectMembers");
            DropTable("dbo.MissionOwners");
            DropTable("dbo.Missions");
            DropTable("dbo.MissionLogs");
            DropTable("dbo.Projects");
            DropTable("dbo.MissionLists");
            DropTable("dbo.Groups");
            DropTable("dbo.Users");
            DropTable("dbo.Annonces");
        }
    }
}
