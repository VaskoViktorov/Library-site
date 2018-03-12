namespace Library.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using Resources.Models.Account;

    using static Data.DataConstants;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(RegisterViewModelResx))]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Username", ResourceType = typeof(RegisterViewModelResx))]
        public string UserName { get; set; }

        [Range(18, 99, ErrorMessageResourceName = "AgeError", ErrorMessageResourceType = typeof(RegisterViewModelResx))]
        [Display(Name = "Age", ResourceType = typeof(RegisterViewModelResx))]
        public int UserAge { get; set; }

        [Required]
        [MinLength(UserFullNameMinLength)]
        [MaxLength(UserFullNameMaxLength)]
        [Display(Name = "FullName", ResourceType = typeof(RegisterViewModelResx))]
        public string UserFullName { get; set; }

        [MinLength(6)]
        [MaxLength(15)]
        [Display(Name = "PhoneNumber", ResourceType = typeof(RegisterViewModelResx))]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "PasswordError", MinimumLength = 6, ErrorMessageResourceType = typeof(RegisterViewModelResx))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(RegisterViewModelResx))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(RegisterViewModelResx))]
        [Compare("Password", ErrorMessageResourceName = "ConfPassError", ErrorMessageResourceType = typeof(RegisterViewModelResx))]
        public string ConfirmPassword { get; set; }
    }
}