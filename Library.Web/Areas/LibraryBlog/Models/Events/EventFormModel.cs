namespace Library.Web.Areas.LibraryBlog.Models.Events
{
    using System.ComponentModel.DataAnnotations;
    using Search;

    public class EventFormModel : SearchFormModel
    {
        public string id { get; set; }

        [Required]
        public string date { get; set; }

        [Required]
        public string type { get; set; } = "meeting";

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string url { get; set; }
    }
}