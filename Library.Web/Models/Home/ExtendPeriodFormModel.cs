namespace Library.Web.Models.Home
{
    using System.ComponentModel.DataAnnotations;
    using Resources.Models.Home;

    public class ExtendPeriodFormModel
    {
        [MinLength(0)]
        [MaxLength(100, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(ExtendPeriodFormModelResx))]
        [Display(Name = "Email", ResourceType = typeof(ExtendPeriodFormModelResx))]
        public string Email { get; set; } = "-";

        [MinLength(0)]
        [MaxLength(50, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(ExtendPeriodFormModelResx))]
        [Display(Name = "UserName", ResourceType = typeof(ExtendPeriodFormModelResx))]
        public string UserName { get; set; } = "-";

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(ExtendPeriodFormModelResx))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(ExtendPeriodFormModelResx))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(ExtendPeriodFormModelResx))]
        [Display(Name = "CardNumber", ResourceType = typeof(ExtendPeriodFormModelResx))]
        public string CardNumber { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(ExtendPeriodFormModelResx))]
        [MinLength(10, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(ExtendPeriodFormModelResx))]
        [MaxLength(500, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(ExtendPeriodFormModelResx))]
        [Display(Name = "BookInfo", ResourceType = typeof(ExtendPeriodFormModelResx))]
        public string BookInfo { get; set; }
    }
}
