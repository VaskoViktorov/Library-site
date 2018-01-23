using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Home;
    using Services;
    using System.Diagnostics;
    using Services.Html;

    using static WebConstants;

    public class HomeController : Controller
    {
        private const string ModelName = "Въпросът";

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

            var htmlString = string.Format(EmailReceiverHtmlText,model.Description,model.Phone,model.Email,model.UserInfo);

            emailSender.SendEmailWithQuestionAsync(email, htmlString);
            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Index()
            => View(new ArticleListingHomeViewModel
            {
                Articles = await home.LatestFourArticlesAsync()
            });

        public IActionResult Contact()
            => View();
        
        public IActionResult History()
            => View();

        public IActionResult MihalakiGeorgiev()
            => View();

        public IActionResult Functions()
            => View();

        public IActionResult Structure()
            => View();

        public IActionResult WorkTime()
            => View();

        public IActionResult PriceList()
            => View();

        public IActionResult Staff()
            => View();

        public IActionResult Faq()
            => View();

        public IActionResult Partners()
            => View();

        public IActionResult Contributors()
            => View();

        public IActionResult Services()
            => View();

        public IActionResult Vidin()
            => View();

        public IActionResult ForTheStudents()
            => View();

        public IActionResult ForTheEnthusiasts()
            => View();

        public IActionResult ProgramForKids()
            => View();

        public IActionResult Internet()
            => View();

        public IActionResult Editions()
            => View();

        public IActionResult Links()
            => View();

        public IActionResult Ecatalogue()
            => View();

        public IActionResult Test()
            => View();

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
