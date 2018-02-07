namespace Library.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(UserFullNameMinLength)]
        [MaxLength(UserFullNameMaxLength)]
        public string UserFullName { get; set; }

        [Range(18, 120)]
        public int UserAge { get; set; }
    }
}