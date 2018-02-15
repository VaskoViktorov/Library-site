namespace Library.Web.Areas.En.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Home;
    using Services;
    using Services.Html;
    using System.Threading.Tasks;

    using static WebConstants;

    [Area(EnglishAreaName)]
    public class HomeController : Controller
    {
        private const string ModelName = "Question";

        private readonly IEmailSender emailSender;
        private readonly IHtmlService html;
        private readonly IHomeService home;

        public HomeController(IEmailSender emailSender, IHtmlService html, IHomeService home)
        {
            this.emailSender = emailSender;
            this.html = html;
            this.home = home;
        }

        public IActionResult Ask()
            => View();

        [HttpPost]
        [ValidateModelState]
        public IActionResult Ask(AskFormModel model)
        {
            model.Description = this.html.Sanitize(model.Description);

            this.TempData.AddSuccessMessage(string.Format(WebConstants.TempDataCreateCommentText, ModelName, ""));

            var email = EmailReceiverForAsk;

            var htmlString = string.Format(EmailReceiverHtmlText, model.Description, model.Phone, model.Email, model.UserInfo);

            emailSender.SendEmailWithQuestionAsync(email, htmlString);

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Index()
            => View(new ArticleListingHomeViewModel()
            {
                Articles = await home.LatestFourArticlesEnAsync()
            });

        public IActionResult Contact()
            => View();

        public IActionResult LibraryPost()
            => View();
    }
}