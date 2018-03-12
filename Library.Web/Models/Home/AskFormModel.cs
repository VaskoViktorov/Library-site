namespace Library.Web.Models.Home
{
    using Resources.Models.Home;
    using System.ComponentModel.DataAnnotations;

    public class AskFormModel
    {
        [MinLength(0)]
        [MaxLength(100)]
        [Display(Name = "Email", ResourceType = typeof(AskFormModelResx))]
        public string Email { get; set; } = "-";

        [MinLength(0)]
        [MaxLength(30)]
        [Display(Name = "Phone", ResourceType = typeof(AskFormModelResx))]
        public string Phone { get; set; } = "-";

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "Name", ResourceType = typeof(AskFormModelResx))]
        public string UserInfo { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        [Display(Name = "Question", ResourceType = typeof(AskFormModelResx))]
        public string Description { get; set; }
    }
}