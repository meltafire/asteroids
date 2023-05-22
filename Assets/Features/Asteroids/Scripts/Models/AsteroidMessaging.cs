using System;

public class AsteroidMessaging : IAsteroidToPlayfieldMessaging, IAsteroidMessaging
{
    private readonly Pool<AsteroidMessaging> _pool;

    public event Action ShowRequest;
    public event Action DestroyRequest;
    public event Action HideRequest;

    public AsteroidMessaging(Pool<AsteroidMessaging> pool)
    {
        _pool = pool;
    }

    public void ReturnToPool()
    {
        _pool.Release(this);
    }

    public void Hide()
    {
        HideRequest?.Invoke();
    }

    public void Show()
    {
        ShowRequest?.Invoke();
    }

    public void RequestDestroy()
    {
        DestroyRequest?.Invoke();
    }
}
