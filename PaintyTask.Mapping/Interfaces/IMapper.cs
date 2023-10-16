namespace PaintyTask.Mapping.Interfaces;

public interface IMapper<T, V>
{
    T Map(V mapInfo);
}