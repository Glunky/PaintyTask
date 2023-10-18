using PaintyTask.Core;
using PaintyTask.Models.Requests;

namespace PaintyTask.BusinessLogic.Interfaces;

public interface ISignInCommand : ICommand<AppResponse<bool>, SignInRequest> { }