namespace Library.Web.Models.Manage
{
    using System.ComponentModel.DataAnnotations;
    using Resources.Models.Manage;

    public class IndexViewModel
    {
        [Display(Name = "Username", ResourceType = typeof(IndexViewModelResx))]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(IndexViewModelResx))]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(IndexViewModelResx))]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}