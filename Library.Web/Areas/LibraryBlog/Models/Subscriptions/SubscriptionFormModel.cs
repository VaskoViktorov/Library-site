namespace Library.Web.Areas.LibraryBlog.Models.Subscriptions
{
    using Data.Models;
    using Resources.Areas.LibraryBlog.Models.Subscriptions;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class SubscriptionFormModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(SubscriptionFormModelResx))]
        [MinLength(SubscriptionNameMinLength, ErrorMessageResourceName = "MinLengthErrorMsg", ErrorMessageResourceType = typeof(SubscriptionFormModelResx))]
        [MaxLength(SubscriptionNameMaxLength, ErrorMessageResourceName = "MaxLengthErrorMsg", ErrorMessageResourceType = typeof(SubscriptionFormModelResx))]
        [Display(Name = "Name", ResourceType = typeof(SubscriptionFormModelResx))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(SubscriptionFormModelResx))]
        [Display(Name = "Department", ResourceType = typeof(SubscriptionFormModelResx))]
        public DepartmentType Department { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(SubscriptionFormModelResx))]
        [Display(Name = "Type", ResourceType = typeof(SubscriptionFormModelResx))]
        public SubscriptionType Type { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(SubscriptionFormModelResx))]
        [Display(Name = "Language", ResourceType = typeof(SubscriptionFormModelResx))]
        public Language Language { get; set; }
    }
}