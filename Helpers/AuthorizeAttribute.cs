using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SalesNet.Model;
using SalesNet.Models.Response;
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var users = (SnEmployee)context.HttpContext.Items["Users"];
        if (users == null)
        {
            /* Not logged in */
            context.Result = new JsonResult(new CommonResponse { resCode = CommonResponseStatus.UNAUTHORIZED, resMessage = CommonResponseMessage.UNAUTHORIZED }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}