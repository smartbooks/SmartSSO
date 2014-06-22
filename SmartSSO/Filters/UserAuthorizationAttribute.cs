using System.Web.Mvc;

namespace SmartSSO.Filters
{
    public class UserAuthorizationAttribute : ActionFilterAttribute
    {
        public static readonly string CookieUserName = "username";
        public static readonly string ManageLoginUrl = "/home/login";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //简单验证cookie中username是否为空
            if (filterContext.HttpContext.Request.Cookies[CookieUserName] == null ||
                string.IsNullOrWhiteSpace(filterContext.HttpContext.Request.Cookies[CookieUserName].Value))
            {
                filterContext.Result = new RedirectResult(ManageLoginUrl);
            }

            //复杂验证逻辑

            base.OnActionExecuting(filterContext);
        }
    }
}