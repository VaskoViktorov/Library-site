namespace Library.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Services.ViewComponents;
    using System.Threading.Tasks;

    public class LatestBooksViewComponent : ViewComponent
    {
        private readonly ILatestBooksService books;

        public LatestBooksViewComponent(ILatestBooksService books)
        {
            this.books = books;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        => View(await books.LatestBooks());
    }
}
