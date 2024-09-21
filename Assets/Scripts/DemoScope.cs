using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

public class DemoScope : LifetimeScope
{
    [Header("Document")]
    [SerializeField] private UIDocument _documentRoot;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<DataSource>(Lifetime.Singleton);
        builder.Register<AdsService>(Lifetime.Singleton).As<IAdsService>();
        builder.Register<ComponentResolver>(Lifetime.Singleton).As<IComponentResolver>();

        // Transient registration - new instance every time
        builder.Register<AdsButton_2>(Lifetime.Transient);

        builder.RegisterBuildCallback(container =>
        {
            // Enable the document root
            // This is a temporary solution to show the UI
            _documentRoot.gameObject.SetActive(true);
            _documentRoot.rootVisualElement.dataSource = container.Resolve<DataSource>();
        });
    }
}
