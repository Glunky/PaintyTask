using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaintyTask.Models.DB;

namespace PaintyTask.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize]
public class UsersController
{
    /*[HttpPost]
    public async Task<string> Execute()
    {
        var x = new DbAppUser();
        x.Images.
    }*/
}