using UnityEngine;
using VContainer;
using VContainer.Unity;

public class DemoScope : LifetimeScope
{
    [Header("Document")]
    [SerializeField] private GameObject _documentRoot;

    protected override void Configure(IContainerBuilder builder)
    {
        Debug.Log("DemoScope Configure");

        builder.Register<AdsService>(Lifetime.Singleton).As<IAdsService>();
        builder.Register<ComponentFactory>(Lifetime.Singleton).As<IComponentFactory>();

        // Transient registration - new instance every time
        builder.Register<AdsButton_2>(Lifetime.Transient);

        builder.RegisterBuildCallback(container =>
        {
            // Resolve the component factory for instant constructor injection
            container.Resolve<IComponentFactory>();

            // Enable the document root
            // This is a temporary solution to show the UI
            _documentRoot.SetActive(true);
        });
    }
}
