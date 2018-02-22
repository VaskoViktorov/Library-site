namespace Library.Web.Areas.Admin.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using LibraryBlog.Models.Search;

    public class AddUserToRoleFormModel : SearchFormModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}