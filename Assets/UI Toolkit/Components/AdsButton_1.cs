using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

[UxmlElement]
public partial class AdsButton_1 : Button
{
    private IAdsService _adsService;

    public AdsButton_1() : this(true)
    {
        this.clicked += OnClick;
        this.resolved += OnResolved;

        Debug.Log("AdsButton_1.Constructor");
    }

    private void OnResolved()
    {
        Debug.Log("AdsButton_1.OnResolved");
    }

    private void OnClick()
    {
        Debug.Log("AdsButton_1.OnClick: AdsService = " + _adsService);
        Debug.Log("AdsButton_1.OnClick: IComponentResolver = " + Resolver);

        if (_adsService != null)
        {
            _adsService.ShowRewarded("placement", (success) => { Debug.Log("ShowRewarded callback: " + success); });
        }
    }
}

// ↓↓↓ THIS CODE SHOULD BE GENERATED BY SOURCE CODE GENERATOR ↓↓↓
public partial class AdsButton_1
{
    private IDataSourceResolver _resolver;
    private event Action resolved;

    [CreateProperty]
    public IDataSourceResolver Resolver
    {
        get => _resolver;
        set { _resolver = value; ResolveDependencies(); }
    }

    public AdsButton_1(bool resolve)
    {
        if (Application.isPlaying is false || resolve is false) return;

        SetBinding(nameof(Resolver), new DataBinding
        {
            dataSourcePath = new PropertyPath(nameof(DataSource.Resolver)),
            bindingMode = BindingMode.ToTargetOnce
        });
    }

    private void ResolveDependencies()
    {
        _adsService = _resolver.Resolve<IAdsService>();

        resolved?.Invoke();
    }
}
