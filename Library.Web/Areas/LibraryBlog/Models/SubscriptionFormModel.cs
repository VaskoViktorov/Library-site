namespace Library.Web.Areas.LibraryBlog.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static Data.DataConstants;

    public class SubscriptionFormModel
    {
        [Required]
        [MinLength(SubscriptionNameMinLength)]
        [MaxLength(SubscriptionNameMaxLength)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [MinLength(SubscriptionDepartmentMinLength)]
        [MaxLength(SubscriptionDepartmentMaxLength)]
        [Display(Name = "Отдел")]
        public string Department { get; set; }

        [Required]
        [Display(Name = "Вид")]
        public SubscriptionType Type { get; set; }
    }
}
