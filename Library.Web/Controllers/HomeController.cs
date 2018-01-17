using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Web.Models;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {        
            return View();
        }

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
