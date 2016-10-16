using System;
using System.ComponentModel.DataAnnotations;

namespace ShauliBlog.Models
{
    public class FansModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "שם פרטי")]
        public String Fname { get; set; }
        [Required]
        [Display(Name = "שם משפחה")]
        public String Lname { get; set; }
        [Required]
        [Display(Name = "מין")]
        public int Gender { get; set; }
        [Required]
        [Display(Name = "תאריך לידה")]
        public DateTime Bdate { get; set; }
        [Display(Name = "ותק")]
        public int seniority { get; set; }
    }
}