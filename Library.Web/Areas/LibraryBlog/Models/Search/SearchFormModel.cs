namespace Library.Web.Areas.LibraryBlog.Models.Search
{
    using System.ComponentModel.DataAnnotations;

    public class SearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Нови Книги")]
        public bool SearchInBooks { get; set; } = true;

        [Display(Name = "Новини")]
        public bool SearchInArticles { get; set; } = true;

        [Display(Name = "Галерии")]
        public bool SearchInGalleries { get; set; } = true;

        [Display(Name = "Абонаменти")]
        public bool SearchInSubscriptions { get; set; } = true;
    }
}
