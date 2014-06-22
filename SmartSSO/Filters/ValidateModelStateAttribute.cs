using System.Web.Mvc;

namespace SmartSSO.Filters
{
    /// <summary>
    /// 默认模型字典验证过滤器
    /// </summary>
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                filterContext.Result = new ViewResult
                {
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData
                };
            }

            base.OnActionExecuting(filterContext);
        }
    }
}