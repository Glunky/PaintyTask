using PaintyTask.Models.DB;
using PaintyTask.Models.Requests;

namespace PaintyTask.Mapping.Interfaces;

public interface ISignUpRequestToDbAppUserMapper : IMapper<DbAppUser, SignUpRequest>
{
    public new DbAppUser Map(SignUpRequest request);
}