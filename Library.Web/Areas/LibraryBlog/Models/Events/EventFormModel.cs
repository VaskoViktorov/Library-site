namespace Library.Web.Areas.LibraryBlog.Models.Events
{
    using Resources.Areas.LibraryBlog.Models.Events;
    using System.ComponentModel.DataAnnotations;

    public class EventFormModel
    {
        public string id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(EventFormModelResx))]
        [Display(Name = "Date", ResourceType = typeof(EventFormModelResx))]
        public string date { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(EventFormModelResx))]
        public string type { get; set; } = "meeting";

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(EventFormModelResx))]
        [Display(Name = "Title", ResourceType = typeof(EventFormModelResx))]
        public string title { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(EventFormModelResx))]
        [Display(Name = "Description", ResourceType = typeof(EventFormModelResx))]
        public string description { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMsg", ErrorMessageResourceType = typeof(EventFormModelResx))]
        [Display(Name = "Url", ResourceType = typeof(EventFormModelResx))]
        public string url { get; set; }
    }
}