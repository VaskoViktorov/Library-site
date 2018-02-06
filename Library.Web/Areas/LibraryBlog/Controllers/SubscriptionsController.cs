namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Subscriptions;
    using Services.LibraryBlog;
    using System.Threading.Tasks;

    public class SubscriptionsController : BaseController
    {
        private const string ModelName = "Абонамента";

        private readonly ISubscriptionService subscriptions;

        public SubscriptionsController(ISubscriptionService subscriptions)
        {
            this.subscriptions = subscriptions;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Subscriptions()
        => this.View(new SubscriptionListingViewModel
        {
            Newspapers = await this.subscriptions.AllNewspapersAsync(),
            Magazines = await this.subscriptions.AllMagazinesAsync()
        });

        public IActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(SubscriptionFormModel model)
        {
            if (await this.subscriptions.UniqueCheckAsync(model.Name))
            {
                this.TempData.AddWarningMessage(string.Format(WebConstants.TempDataAlreadyExistsText, ModelName, model.Name));

                return this.RedirectToAction(nameof(this.Create));
            }

            await this.subscriptions.CreateAsync(model.Name, model.Department, model.Type, model.Language);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataCreateCommentText, ModelName, string.Empty));

            return this.RedirectToAction(nameof(this.Subscriptions));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var subscription = await this.subscriptions.ByIdAsync(id);

            if (subscription == null)
            {
                return this.NotFound();
            }

            return this.View(new SubscriptionFormModel
            {
                Name = subscription.Name,
                Department = subscription.Department,
                Type = subscription.Type
            });
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, SubscriptionFormModel model)
        {
            await this.subscriptions.EditAsync(id, model.Name, model.Department, model.Type, model.Language);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataEditCommentText, ModelName, string.Empty));

            return this.RedirectToAction(nameof(this.Subscriptions));
        }

        public IActionResult Delete(int id)
            => this.View(id);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.subscriptions.DeleteAsync(id);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataDeleteCommentText, ModelName, string.Empty));

            return this.RedirectToAction(nameof(this.Subscriptions));
        }

    }
}
