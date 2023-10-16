using PaintyTask.Mapping.Interfaces;
using PaintyTask.Models.DB;
using PaintyTask.Models.Requests;

namespace PaintyTask.Mapping.Implementation;

public class SignUpRequestToDbAppUserMapper : ISignUpRequestToDbAppUserMapper
{
    public DbAppUser Map(SignUpRequest request)
    {
        return new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = request.AppUserInfo.Login,
        };
    }
}