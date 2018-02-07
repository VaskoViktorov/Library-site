namespace Library.Web.Areas.En.Controllers
{
    using LibraryBlog.Models.Subscriptions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.LibraryBlog;
    using System.Threading.Tasks;

    [Area(WebConstants.EnglishAreaName)]
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionService subscriptions;

        public SubscriptionsController(ISubscriptionService subscriptions)
        {
            this.subscriptions = subscriptions;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Subscriptions()
        => this.View(new SubscriptionListingViewModel
        {
            Newspapers = await this.subscriptions.AllNewspapersEnAsync(),
            Magazines = await this.subscriptions.AllMagazinesEnAsync()
        });
    }
}