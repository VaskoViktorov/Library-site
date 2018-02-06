namespace Library.Web.Areas.En.ViewComponents
{
    using Services.ViewComponents;
    using Microsoft.AspNetCore.Mvc;   
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
