using Microsoft.AspNetCore.Mvc;
using PaintyTask.BusinessLogic.Interfaces;
using PaintyTask.Core;
using PaintyTask.Models.Requests;

namespace PaintyTask.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ISignUpCommand _signUpCommand;
    private readonly ISignInCommand _signInCommand;
        
    public AuthController(
        [FromServices] ISignUpCommand signUpCommand,
        [FromServices] ISignInCommand signInCommand
        )
    {
        _signUpCommand = signUpCommand;
        _signInCommand = signInCommand;
    }

    [HttpPost("signUp")]
    public async Task<AppResponse<string>> Execute([FromBody] SignUpRequest request)
    {
        return await _signUpCommand.Execute(request);
    }

    [HttpPost("signIn")]
    public async Task<AppResponse<bool>> Execute([FromBody] SignInRequest request)
    {
        return await _signInCommand.Execute(request);
    }
}