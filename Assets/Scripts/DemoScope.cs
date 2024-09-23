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
        builder.Register<AdsService>(Lifetime.Singleton).As<IAdsService>();

        builder.Register<DataSource>(Lifetime.Singleton);
        builder.Register<DataSourceResolver>(Lifetime.Singleton).As<IDataSourceResolver>();

        builder.RegisterBuildCallback(container =>
        {
            _documentRoot.rootVisualElement.dataSource = container.Resolve<DataSource>();
        });
    }
}
