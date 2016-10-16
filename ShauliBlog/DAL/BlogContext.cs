using ShauliBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShauliBlog.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogContext")
        {
        }
        
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<FansModel> Fans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove < PluralizingTableNameConvention>();


            modelBuilder.Entity<CommentModel>()
                .HasMany(c => c.Posts).WithMany(i => i.Comments)
                .Map(t => t.MapLeftKey("CommentID")
                    .MapRightKey("PostID")
                    .ToTable("PostComment"));

           

        }
    }
}