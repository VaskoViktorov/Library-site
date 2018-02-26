namespace Library.Web.Areas.LibraryBlog.Models.Events
{
    using System.ComponentModel.DataAnnotations;
    using Search;
    using Resources.Areas.LibraryBlog.Models.Events;

    public class EventFormModel : SearchFormModel
    {
        public string id { get; set; }

        [Required]
        [Display(Name = "Date", ResourceType = typeof(EventFormModelResx))]
        public string date { get; set; }

        [Required]
        public string type { get; set; } = "meeting";

        [Required]
        [Display(Name = "Title", ResourceType = typeof(EventFormModelResx))]
        public string title { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(EventFormModelResx))]
        public string description { get; set; }

        [Required]
        [Display(Name = "Url", ResourceType = typeof(EventFormModelResx))]
        public string url { get; set; }
    }
}