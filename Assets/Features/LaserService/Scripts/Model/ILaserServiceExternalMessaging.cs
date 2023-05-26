using System;

public interface ILaserServiceExternalMessaging
{
    event Action<int> ShotCountChange;
    event Action<float> TimeChange;

    int RequestShotCount();
    float RequestTime();
}
