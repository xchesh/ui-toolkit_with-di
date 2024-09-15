using System;
using UnityEngine;

public interface IAdsService
{
    bool ShowRewarded(string placement, Action<bool> callback);
    bool ShowInterstitial(string placement, Action callback);
}
