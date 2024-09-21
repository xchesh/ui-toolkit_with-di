

using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

// Do not use component factory directly in the code
// No singletons, no service locator, no manual injection!
public class ComponentResolver : IComponentResolver
{
    private readonly LifetimeScope _scope;

    public ComponentResolver(LifetimeScope scope)
    {
        _scope = scope;

        Debug.Log("ComponentResolver created");
    }

    public T Resolve<T>()
    {
        // Resolve the type from the container
        return _scope.Container.Resolve<T>();
    }
}
