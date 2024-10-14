using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using WhatDoYouOwn_ASPNET.Models;

namespace WhatDoYouOwn_ASPNET.Filters
{
    public class LoggedUserPages : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string userSession = context.HttpContext.Session.GetString("UserSessionLoged");

            if (String.IsNullOrEmpty(userSession))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "singin" }, { "action", "index" } });
            }
            else
            {
                UserModel model = JsonConvert.DeserializeObject<UserModel>(userSession);

                if (model == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "singin" }, { "action", "index" } });
                }

                base.OnActionExecuted(context);
            }
        }
    }
}
