using PaintyTask.Core;
using PaintyTask.Models.DTO;

namespace PaintyTask.BusinessLogic.Interfaces;

public interface IUploadImageCommand : ICommand<AppResponse<bool>, Image> { }