using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace jQuery.Filters
{
    public class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.Headers["X-Requested-With"].Equals("XMLHttpRequest"))
            {
                filterContext.HttpContext.Response.StatusCode = 404;
                filterContext.Result = new StatusCodeResult(404);
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
