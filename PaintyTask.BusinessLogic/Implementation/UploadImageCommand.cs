using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PaintyTask.BusinessLogic.Interfaces;
using PaintyTask.Core;
using PaintyTask.Models.DTO;

namespace PaintyTask.BusinessLogic.Implementation;

public class UploadImageCommand : IUploadImageCommand
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _config;

    public UploadImageCommand(
        [FromServices] IHttpContextAccessor httpContextAccessor,
        [FromServices] IConfiguration configuration)
    {
        _httpContextAccessor = httpContextAccessor;
        _config = configuration;
    }
    
    public async Task<AppResponse<bool>> Execute(Image request)
    {
        string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
        string storagePath = _config.GetValue<string>("ImagesRelativePath").Replace("/", @"\");
        string dirPath = @$"{Environment.CurrentDirectory}\{storagePath}\{userName}";
        
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        // TODO Add Errors and http codes
        using (FileStream fs = File.Create(Path.Combine(dirPath, request.Name)))
        {
            await request.Content.CopyToAsync(fs);
            await fs.FlushAsync();
            
            _httpContextAccessor.HttpContext!.Response.StatusCode = (int)HttpStatusCode.Created;
            // TODO: add logger
            return new()
            {
                Status = ResultStatus.Succeed,
                Body = true
            };
        }
    }
}