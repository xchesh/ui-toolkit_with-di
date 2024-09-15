using UnityEngine;
using UnityEngine.UIElements;

[UxmlElement]
public partial class AdsButton_1 : Button
{
    // How to inject IAdsService without extra code in the class?
    // No singletons, no service locator, no manual injection
    private IAdsService _adsService;

    public AdsButton_1()
    {
        Debug.Log("AdsButton_1 created using default constructor");

        this.clicked += OnClick;
    }

    private void OnClick()
    {
        Debug.Log("AdsButton_1 clicked");

        if (_adsService != null)
        {
            _adsService.ShowRewarded("placement", (success) =>
            {
                Debug.Log("ShowRewarded callback: " + success);
            });
        }
    }
}
