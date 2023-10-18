using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaintyTask.BusinessLogic.Interfaces;
using PaintyTask.Core;
using PaintyTask.Models.DTO;

namespace PaintyTask.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ImagesController
{
    private readonly IUploadImageCommand _uploadImageCommand;

    public ImagesController(
        [FromServices] IUploadImageCommand uploadImageCommand)
    {
        _uploadImageCommand = uploadImageCommand;
    }
    
    [HttpPost("upload")]
    public async Task<AppResponse<bool>> Execute([FromForm] Image image)
    {
        return await _uploadImageCommand.Execute(image);
    }
}