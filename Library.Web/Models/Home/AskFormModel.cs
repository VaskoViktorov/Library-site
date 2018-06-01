namespace Library.Web.Models.Home
{
    using Resources.Models.Home;
    using System.ComponentModel.DataAnnotations;

    public class AskFormModel
    {
        [MinLength(0)]
        [MaxLength(100, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(AskFormModelResx))]
        [Display(Name = "Email", ResourceType = typeof(AskFormModelResx))]
        public string Email { get; set; } = "-";

        [MinLength(0)]
        [MaxLength(30, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(AskFormModelResx))]
        [Display(Name = "Phone", ResourceType = typeof(AskFormModelResx))]
        public string Phone { get; set; } = "-";

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(AskFormModelResx))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(AskFormModelResx))]
        [MaxLength(200, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(AskFormModelResx))]
        [Display(Name = "Name", ResourceType = typeof(AskFormModelResx))]
        public string UserInfo { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(AskFormModelResx))]
        [MinLength(5, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(AskFormModelResx))]
        [MaxLength(2000, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(AskFormModelResx))]
        [Display(Name = "Question", ResourceType = typeof(AskFormModelResx))]
        public string Description { get; set; }
    }
}