

using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

// Do not use component factory directly in the code
// No singletons, no service locator, no manual injection!
public class ComponentFactory : IComponentFactory
{
    // Choice between lesser evils.
    // Supporting one singleton is much easier than hundreds of thousands
    // If you can make set custom VisualElement factory into IPanel - this is the best solution
    public static IComponentFactory Instance { get; private set; }

    private readonly LifetimeScope _scope;

    public ComponentFactory(LifetimeScope scope)
    {
        Instance = this;

        _scope = scope;

        Debug.Log("ComponentFactory created");
    }

    public T Create<T>() where T : VisualElement
    {
        Debug.Log("Creating " + typeof(T).Name);
        // Resolve the type from the container
        // This will create a new instance of the type
        return _scope.Container.Resolve<T>();
    }
}
