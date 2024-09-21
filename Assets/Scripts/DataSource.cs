using System;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine.UIElements;

public class DataSource : IDataSourceViewHashProvider, INotifyBindablePropertyChanged
{
    private long m_ViewVersion;

    private int m_Value = 11;
    private IAdsService m_AdsService;

    public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;

    [CreateProperty]
    public int value
    {
        get => m_Value;
        set
        {
            if (m_Value == value)
                return;
            m_Value = value;
            Notify();
        }
    }

    [CreateProperty]
    public IAdsService adsService
    {
        get => m_AdsService;
        set
        {
            if (m_AdsService == value)
                return;
            m_AdsService = value;
            Notify();
        }
    }

    [CreateProperty]
    public IComponentResolver componentResolver { get; }

    public DataSource(IAdsService adsService, IComponentResolver resolver)
    {
        componentResolver = resolver;
        m_AdsService = adsService;
    }

    public void Publish()
    {
        ++m_ViewVersion;
    }

    public long GetViewHashCode()
    {
        return m_ViewVersion;
    }

    void Notify([CallerMemberName] string property = "")
    {
        propertyChanged?.Invoke(this, new BindablePropertyChangedEventArgs(property));
    }
}
