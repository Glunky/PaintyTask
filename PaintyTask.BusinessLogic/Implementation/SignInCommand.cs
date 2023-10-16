using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaintyTask.BusinessLogic.Interfaces;
using PaintyTask.Core;
using PaintyTask.Models.DB;
using PaintyTask.Models.Requests;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WebBaraholkaAPI.Business.Commands.Implementations.Auth;

public class SignInCommand : ISignInCommand
{
    private readonly SignInManager<DbAppUser> _signInManager;
    private readonly ILogger<SignInCommand> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SignInCommand(
        [FromServices] SignInManager<DbAppUser> signInManager,
        [FromServices] ILogger<SignInCommand> logger,
        [FromServices] IHttpContextAccessor httpContextAccessor)
    {
        _signInManager = signInManager;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<AppResponse<bool>> Execute(SignInRequest request)
    {
        SignInResult result = await _signInManager.PasswordSignInAsync(
            request.AppUserInfo.Login, 
            request.AppUserInfo.Password, 
            false, 
            false
            );

        if (result.Succeeded)
        {
            _logger.LogInformation("User {UserID} successfully authorized", request.AppUserInfo.Login);
            
            return new()
            {
                Status = ResultStatus.Succeed, 
                Body = result.Succeeded
            };
        }

        string errorMsg = $"Failed to authorized user {request.AppUserInfo.Login}";
        _httpContextAccessor.HttpContext!.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

        _logger.LogInformation(errorMsg);

        return new()
        {
            Status = ResultStatus.Failed, 
            Body = result.Succeeded,
            Errors = new List<string> {errorMsg}
        };
    }
}