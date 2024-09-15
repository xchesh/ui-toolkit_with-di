using System;

public class AdsService : IAdsService
{
    public bool ShowInterstitial(string placement, Action callback)
    {
        // Show interstitial video and invoke callback after user closed video
        callback?.Invoke();

        // true - if interstitial was shown
        // false - if interstitial was not shown
        return true;
    }

    public bool ShowRewarded(string placement, Action<bool> callback)
    {
        // Show rewarded video and invoke callback after user closed video
        // true - if user watched video till the end
        // false - if user closed video before the end
        callback?.Invoke(true);

        return true;
    }
}
