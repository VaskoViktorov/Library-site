namespace Library.Web.Areas.LibraryBlog.Models.Surveys
{
    using Resources.Areas.LibraryBlog.Models.Surveys;
    using System.ComponentModel.DataAnnotations;

    public class SurveyFormModel
    {
        public string id { get; set; }

        [Required]
        [Display(Name = "Url", ResourceType = typeof(SurveyFormModelResx))]
        public string url { get; set; }
    }
}