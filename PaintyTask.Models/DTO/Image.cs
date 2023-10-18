using Microsoft.AspNetCore.Http;

namespace PaintyTask.Models.DTO;

public class Image
{
    public string Name { get; set; }
    public IFormFile Content { get; set; }
}