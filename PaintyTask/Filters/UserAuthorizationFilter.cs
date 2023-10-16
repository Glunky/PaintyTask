using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using PaintyTask.Core;

namespace PaintyTask.Filters;

public class UserAuthorizationFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new ObjectResult(new AppResponse<string>
            {
                Status = ResultStatus.Failed,
                Body = null,
                Errors = new List<string>
                {
                    "User is unauthorized"
                }
            });
        }
    }
}