namespace Library.Web.Areas.LibraryBlog.Models.Subscriptions
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using Search;
    using static Data.DataConstants;

    public class SubscriptionFormModel : SearchFormModel
    {
        [Required]
        [MinLength(SubscriptionNameMinLength)]
        [MaxLength(SubscriptionNameMaxLength)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Отдел")]
        public DepartmentType Department { get; set; }

        [Required]
        [Display(Name = "Вид")]
        public SubscriptionType Type { get; set; }

        [Required]
        [Display(Name = "Език")]
        public Language Language { get; set; }
    }
}