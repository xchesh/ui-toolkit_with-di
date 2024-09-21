using UnityEngine;
using UnityEngine.UIElements;
using System;

[UxmlElement]
public partial class AdsButton_2 : Button
{
    private IAdsService _adsService;

    public AdsButton_2()
    {
        Debug.Log("AdsButton_2 created using default constructor");
    }

    public AdsButton_2(IAdsService adsService) : base()
    {
        _adsService = adsService;

        Debug.Log("AdsButton_2 created using custom constructor");
        Debug.Log("IAdsService exists: " + (_adsService != null));

        this.clicked += OnClick;
    }

    private void OnClick()
    {
        Debug.Log("AdsButton_2 clicked. Button name: " + name);

        if (_adsService != null)
        {
            // Placement should be a uxml property
            // But now this button is not used UxmlElement attribute
            _adsService.ShowRewarded("placement", (success) =>
            {
                Debug.Log("ShowRewarded callback: " + success);
            });
        }
    }
}
