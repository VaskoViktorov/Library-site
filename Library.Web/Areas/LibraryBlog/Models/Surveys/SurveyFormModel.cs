namespace Library.Web.Areas.LibraryBlog.Models.Surveys
{
    using System.ComponentModel.DataAnnotations;
    using Search;

    public class SurveyFormModel : SearchFormModel
    {
        public string id { get; set; }

        [Required]
        public string url { get; set; }
    }
}