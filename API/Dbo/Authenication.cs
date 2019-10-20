using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Owin.Security.Jwt;

namespace API.Dbo
{
    public class Authenication : AuthorizationFilterAttribute
    {
        //public override void OnAuthorization(HttpActionContext filterContext)
        //{
        //    if(!IsUserAuthorized(filterContext))
        //    {
        //        ShowAuthenticationError(filterContext);
        //        return;
        //    }
        //    base.OnAuthorization(filterContext);
        //}
    }
}