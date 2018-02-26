namespace Library.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using Resources.Models.Account;

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(ForgotPasswordViewModelResx))]
        public string Email { get; set; }
    }
}
