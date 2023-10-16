namespace PaintyTask.BusinessLogic.Interfaces;

public interface ICommand<T, V>
{
    Task<T> Execute(V request);
}