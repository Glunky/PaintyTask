using PaintyTask.Core;
using PaintyTask.Models.Requests;

namespace PaintyTask.BusinessLogic.Interfaces;

public interface ISignUpCommand : ICommand<AppResponse<string>, SignUpRequest> { }