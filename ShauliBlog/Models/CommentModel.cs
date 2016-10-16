using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models
{
    public class CommentModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PostModelID { get; set; }
        [Required]
        [Display(Name = "נושא")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "שם המחבר")]
        public string CommentAuthor { get; set; }
        [Required]
        [Display(Name = "אתר מחבר ההערה")]
        public string CommentAuthorWebSite { get; set; }
        [Required]
        [Display(Name = "תוכן ההערה")]
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual ICollection<PostModel> Posts { get; set; }
    }
}