
using Zenject;

public class DataSourceResolver : IDataSourceResolver
{
    private readonly DiContainer _diContainer;

    public DataSourceResolver(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public T Resolve<T>()
    {
        // Resolve the type from the container
        return _diContainer.Resolve<T>();
    }
}
