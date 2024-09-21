using UnityEngine.UIElements;

public interface IComponentResolver
{
    T Resolve<T>();
}
