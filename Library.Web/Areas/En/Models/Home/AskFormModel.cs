namespace Library.Web.Areas.En.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    public class AskFormModel
    {
        [MinLength(0)]
        [MaxLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; } = "-";

        [MinLength(0)]
        [MaxLength(30)]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = "-";

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "First & Last name")]
        public string UserInfo { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        [Display(Name = "Question")]
        public string Description { get; set; }
    }
}
