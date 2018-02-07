namespace Library.Web.Areas.LibraryBlog.Models.Surveys
{
    using System.ComponentModel.DataAnnotations;

    public class SurveyFormModel
    {
        public string id { get; set; }

        [Required]
        public string url { get; set; }
    }
}