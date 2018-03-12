namespace Library.Web.Models.Account
{
    using Resources.Models.Account;
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(ForgotPasswordViewModelResx))]
        public string Email { get; set; }
    }
}
