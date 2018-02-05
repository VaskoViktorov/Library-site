namespace Library.Web.Areas.En.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;

    [Area(EnglishAreaName)]
    public class HomeController : Controller
    {

        public IActionResult Index()
            => View();

    }
}
