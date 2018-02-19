namespace Library.Web.ViewComponents
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class SearchViewComponent : ViewComponent
    {
        [AllowAnonymous]
        public IViewComponentResult Invoke()
        {          
            return this.View();
        }
    }
}
