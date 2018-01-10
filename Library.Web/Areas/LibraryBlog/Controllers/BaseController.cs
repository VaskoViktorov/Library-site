using Microsoft.AspNetCore.Authorization;

namespace Library.Web.Areas.LibraryBlog.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;

    [Area(LibraryAreaName)]
    [Authorize(Roles = LibrarianAuthorRole)]
    public class BaseController : Controller
    {

    }
}
