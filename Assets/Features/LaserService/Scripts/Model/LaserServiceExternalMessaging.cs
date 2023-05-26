using System;

public class LaserServiceExternalMessaging : ILaserServiceExternalMessaging
{
    public event Func<int> ShotCountRequested;
    public event Func<float> TimeRequested;

    public event Action<int> ShotCountChange;
    public event Action<float> TimeChange;

    public int RequestShotCount()
    {
        return ShotCountRequested();
    }

    public float RequestTime()
    {
        return TimeRequested();
    }

    public void ReportShotCount(int count)
    {
        ShotCountChange?.Invoke(count);
    }

    public void ReportTime(float time)
    {
        TimeChange?.Invoke(time);
    }
}
