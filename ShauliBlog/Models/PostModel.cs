using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models
{
    public class PostModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name ="נושא")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "מחבר הפוסט")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "כתובת אתר המחבר")]
        public string AuthWebSite { get; set; }
        [Required]
        [Display(Name = "תאריך פרסום הפוסט")]
        public DateTime PostDate { get; set; }
        [Required]
        [Display(Name = "תוכן")]
        public string PostText { get; set; }
        [Display(Name = "תמונה")]
        public string ImgLink { get; set; }
        [Display(Name = "וידאו")]
        public string VidLink { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }
    }
}