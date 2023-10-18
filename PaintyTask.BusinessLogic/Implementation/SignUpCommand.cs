using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaintyTask.BusinessLogic.Interfaces;
using PaintyTask.Core;
using PaintyTask.Mapping.Interfaces;
using PaintyTask.Models.DB;
using PaintyTask.Models.Requests;

namespace PaintyTask.BusinessLogic.Implementation;

public class SignUpCommand : ISignUpCommand
{
    private readonly ILogger<SignUpCommand> _logger;
    private readonly UserManager<DbAppUser> _userManager;
    private readonly ISignUpRequestToDbAppUserMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SignUpCommand(
        [FromServices] ILogger<SignUpCommand> logger,
        [FromServices] UserManager<DbAppUser> userManager,
        [FromServices] ISignUpRequestToDbAppUserMapper mapper,
        [FromServices] IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _userManager = userManager;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<AppResponse<string>> Execute(SignUpRequest request)
    {
        DbAppUser appUser = _mapper.Map(request);
        IdentityResult result = await _userManager.CreateAsync(appUser, request.AppUserInfo.Password);
        
        if (result.Succeeded)
        {
            _httpContextAccessor.HttpContext!.Response.StatusCode = (int)HttpStatusCode.Created;
            _logger.LogInformation("Created new user {UserID}", appUser.Id);
            
            return new()
            {
                Status = ResultStatus.Succeed, 
                Body = appUser.Id
            };
        }
        
        _logger.LogInformation("Failed to create user with id {UserID}", appUser.Id);
        _httpContextAccessor.HttpContext!.Response.StatusCode = (int)HttpStatusCode.Conflict;
        
        return new ()
        {
            Status = ResultStatus.Failed, 
            Body = String.Empty,
            Errors = result.Errors.Select(e => e.Description).ToList()
        };
    }
}