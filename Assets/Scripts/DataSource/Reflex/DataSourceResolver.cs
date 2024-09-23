using Reflex.Core;

public class DataSourceResolver : IDataSourceResolver
{
    private readonly Container _container;

    public DataSourceResolver(Container container)
    {
        _container = container;
    }

    public T Resolve<T>()
    {
        // Resolve the type from the container
        return _container.Single<T>();
    }
}
