namespace Library.Web.Models.Home
{
    using System.ComponentModel.DataAnnotations;
    using Resources.Models.Home;

    public class ExtendPeriodFormModel
    {
        [MinLength(0)]
        [MaxLength(100)]
        [Display(Name = "Email", ResourceType = typeof(ExtendPeriodFormModelResx))]
        public string Email { get; set; } = "-";

        [MinLength(0)]
        [MaxLength(30)]
        [Display(Name = "UserName", ResourceType = typeof(ExtendPeriodFormModelResx))]
        public string UserName { get; set; } = "-";

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "CardNumber", ResourceType = typeof(ExtendPeriodFormModelResx))]
        public string CardNumber { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        [Display(Name = "BookInfo", ResourceType = typeof(ExtendPeriodFormModelResx))]
        public string BookInfo { get; set; }
    }
}
