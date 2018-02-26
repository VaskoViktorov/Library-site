namespace Library.Web.Areas.LibraryBlog.Models.Search
{
    using System.ComponentModel.DataAnnotations;
    using Resources.Areas.LibraryBlog.Models.Search;

    public class SearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Books", ResourceType = typeof(SearchFormModelResx))]
        public bool SearchInBooks { get; set; } = true;

        [Display(Name = "Articles", ResourceType = typeof(SearchFormModelResx))]
        public bool SearchInArticles { get; set; } = true;

        [Display(Name = "Galleries", ResourceType = typeof(SearchFormModelResx))]
        public bool SearchInGalleries { get; set; } = true;

        [Display(Name = "Subscriptions", ResourceType = typeof(SearchFormModelResx))]
        public bool SearchInSubscriptions { get; set; } = true;
    }
}
