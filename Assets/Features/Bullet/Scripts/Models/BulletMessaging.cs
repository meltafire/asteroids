using System;

public class BulletMessaging : IBulletMessaging, IBulletToPlayfieldMessaging
{
    private readonly Pool<BulletMessaging> _pool;

    public event Action ShowRequest;
    public event Action DestroyRequest;
    public event Action HideRequest;
    public event Action<IBulletToPlayfieldMessaging> OnCollision;

    public BulletMessaging(Pool<BulletMessaging> pool)
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

    public void ReportCollision()
    {
        OnCollision?.Invoke(this);
    }
}
