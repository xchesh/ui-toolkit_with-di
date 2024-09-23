using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

[UxmlElement]
public partial class AdsButton_3 : Button
{
    [CreateProperty]
    private IAdsService AdsService { get; set; }

    public AdsButton_3()
    {
        this.clicked += OnClick;

        Debug.Log("AdsButton_3.Constructor");
    }

    private void OnClick()
    {
        Debug.Log("AdsButton_3.OnClick: AdsService = " + AdsService);

        if (AdsService != null)
        {
            AdsService.ShowRewarded("placement", (success) => { Debug.Log("ShowRewarded callback: " + success); });
        }
    }
}

