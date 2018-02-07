namespace Library.Web.Areas.En.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Services.ViewComponents;
    using System.Threading.Tasks;

    public class LatestBooksEnViewComponent : ViewComponent
    {
        private readonly ILatestBooksService books;

        public LatestBooksEnViewComponent(ILatestBooksService books)
        {
            this.books = books;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        => View(await books.LatestBooksEn());
    }
}