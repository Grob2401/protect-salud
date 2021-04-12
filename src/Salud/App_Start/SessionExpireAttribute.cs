using System.Web;
using System.Web.Mvc;

namespace Salud.App_Start
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            if (HttpContext.Current.Session["NombreUsuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Usuario/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}