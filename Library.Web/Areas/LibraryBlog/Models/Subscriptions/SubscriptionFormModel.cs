namespace Library.Web.Areas.LibraryBlog.Models.Subscriptions
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using Search;
    using Resources.Areas.LibraryBlog.Models.Subscriptions;

    using static Data.DataConstants;

    public class SubscriptionFormModel : SearchFormModel
    {
        [Required]
        [MinLength(SubscriptionNameMinLength)]
        [MaxLength(SubscriptionNameMaxLength)]
        [Display(Name = "Name", ResourceType = typeof(SubscriptionFormModelResx))]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Department", ResourceType = typeof(SubscriptionFormModelResx))]
        public DepartmentType Department { get; set; }

        [Required]
        [Display(Name = "Type", ResourceType = typeof(SubscriptionFormModelResx))]
        public SubscriptionType Type { get; set; }

        [Required]
        [Display(Name = "Language", ResourceType = typeof(SubscriptionFormModelResx))]
        public Language Language { get; set; }
    }
}