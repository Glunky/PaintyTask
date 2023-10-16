namespace PaintyTask.Core;

public class AppResponse<T>
{
    public T? Body { get; set; }
    public string Status { get; set; }
    public List<string> Errors { get; set; }
}