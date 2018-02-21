namespace Library.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Services.ViewComponents;
    using System.Threading.Tasks;
    using System.Globalization;

    public class LatestBooksViewComponent : ViewComponent
    {
        private readonly ILatestBooksService books;

        public LatestBooksViewComponent(ILatestBooksService books)
        {
            this.books = books;
        }

        public async Task<IViewComponentResult> InvokeAsync()
            => View(await books.LatestBooks(CultureInfo.CurrentCulture.Name));
    }
}
