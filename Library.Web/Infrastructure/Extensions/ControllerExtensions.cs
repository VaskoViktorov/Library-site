using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Checks if the model is valid before returning the view.
        /// </summary>
        public static IActionResult ViewOrNotFound(this Controller controller, object model)
        {
            if (model == null)
            {
                return controller.NotFound();
            }

            return controller.View(model);
        }
    }
}
