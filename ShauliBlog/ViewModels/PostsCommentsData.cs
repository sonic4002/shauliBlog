using ShauliBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShauliBlog.ViewModels
{
    public class PostsCommentsData
    {
        public IEnumerable<PostModel> posts { get; set; }
        public IQueryable<PostModel> posts2 { get; set; }
        public PostModel post { get; set; }
        public CommentModel comment { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}