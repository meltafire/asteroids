using System;

public class LaserMessaging : ILaserToPlayfieldMessaging, ILaserMessaging
{
    public event Action ShowRequest;
    public event Action HideRequest;

    public void Hide()
    {
        HideRequest?.Invoke();
    }

    public void Show()
    {
        ShowRequest?.Invoke();
    }
}
