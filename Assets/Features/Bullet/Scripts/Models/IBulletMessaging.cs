using System;

public interface IBulletMessaging
{
    public event Action ShowRequest;
    public event Action DestroyRequest;
    public event Action HideRequest;
}
