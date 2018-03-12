namespace Library.Web.Models.Account
{
    using Resources.Models.Account;
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(LoginViewModelResx))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(LoginViewModelResx))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(LoginViewModelResx))]
        public bool RememberMe { get; set; }
    }
}
