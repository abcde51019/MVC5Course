﻿using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class LocalOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.RequestContext.HttpContext.Request.IsLocal)
            {
                //判斷是否本機連線
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}