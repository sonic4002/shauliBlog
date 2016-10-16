namespace ShauliBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostModel", "PostDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PostModel", "PostDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostModel", "PostDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PostModel", "PostDate");
        }
    }
}
