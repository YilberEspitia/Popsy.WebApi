using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Popsy.Attributes
{
    /// <summary>
    /// Atributo que indica que APIS no serán accesibles en producción.
    /// </summary>
    public class DisableAPIAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Ejecución de la API.
        /// </summary>
        /// <param name="context"><see cref="ActionExecutingContext"/> objeto.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IWebHostEnvironment environment = context.HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();

            if (!environment.IsDevelopment())
                context.Result = new NotFoundResult();

            base.OnActionExecuting(context);
        }
    }
}
