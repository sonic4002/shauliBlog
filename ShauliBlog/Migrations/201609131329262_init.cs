namespace ShauliBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentModel", "PostModelID", "dbo.PostModel");
            DropIndex("dbo.CommentModel", new[] { "PostModelID" });
            CreateTable(
                "dbo.PostComment",
                c => new
                    {
                        CommentID = c.Int(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CommentID, t.PostID })
                .ForeignKey("dbo.CommentModel", t => t.CommentID, cascadeDelete: true)
                .ForeignKey("dbo.PostModel", t => t.PostID, cascadeDelete: true)
                .Index(t => t.CommentID)
                .Index(t => t.PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComment", "PostID", "dbo.PostModel");
            DropForeignKey("dbo.PostComment", "CommentID", "dbo.CommentModel");
            DropIndex("dbo.PostComment", new[] { "PostID" });
            DropIndex("dbo.PostComment", new[] { "CommentID" });
            DropTable("dbo.PostComment");
            CreateIndex("dbo.CommentModel", "PostModelID");
            AddForeignKey("dbo.CommentModel", "PostModelID", "dbo.PostModel", "ID", cascadeDelete: true);
        }
    }
}
