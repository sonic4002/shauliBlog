namespace ShauliBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostModelID = c.Int(nullable: false),
                        Subject = c.String(nullable: false),
                        CommentAuthor = c.String(nullable: false),
                        CommentAuthorWebSite = c.String(nullable: false),
                        CommentText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostModel", t => t.PostModelID, cascadeDelete: true)
                .Index(t => t.PostModelID);
            
            CreateTable(
                "dbo.PostModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        AuthWebSite = c.String(nullable: false),
                        Published = c.DateTime(nullable: false),
                        PostText = c.String(nullable: false),
                        ImgLink = c.String(),
                        VidLink = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FansModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false),
                        Lname = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Bdate = c.DateTime(nullable: false),
                        seniority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentModel", "PostModelID", "dbo.PostModel");
            DropIndex("dbo.CommentModel", new[] { "PostModelID" });
            DropTable("dbo.FansModel");
            DropTable("dbo.PostModel");
            DropTable("dbo.CommentModel");
        }
    }
}
