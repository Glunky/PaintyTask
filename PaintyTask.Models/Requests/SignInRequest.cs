using PaintyTask.Models.DTO;

namespace PaintyTask.Models.Requests;

public class SignInRequest
{
    public AppUserInfo AppUserInfo { get; set; }
}