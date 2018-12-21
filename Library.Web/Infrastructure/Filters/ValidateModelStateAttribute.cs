namespace Library.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Linq;

    using static WebConstants;

    /// <summary>
    /// This action filter validates the model state, 
    /// when the action contains model, with the word "model" in its name.
    /// </summary>
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        private const string Model = ModelName;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var controller = context.Controller as Controller;

                var model = context.ActionArguments.FirstOrDefault(a => a.Key.ToLower().Contains(Model)).Value;

                if (controller == null || model == null)
                {
                    return;
                }

                context.Result = controller.View(model);

            }
            base.OnActionExecuting(context);
        }
    }
}
