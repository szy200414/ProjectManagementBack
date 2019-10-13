namespace ProjectManagementBack.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addprojectcoverImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "CoverImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "CoverImage");
        }
    }
}
