using System;
using UnityEngine;

public class AsteroidMessaging : IAsteroidToPlayfieldMessaging, IAsteroidMessaging
{
    private readonly Pool<AsteroidMessaging> _pool;
    private readonly AsteroidType _asteroidType;

    public AsteroidType AsteroidType => _asteroidType;

    public event Action<Vector3, Vector3> ShowRequest;
    public event Action DestroyRequest;
    public event Action HideRequest;
    public event Action<IAsteroidToPlayfieldMessaging> BulletCollisionReported;
    public event Func<Vector3> PositionRequest;

    public AsteroidMessaging(Pool<AsteroidMessaging> pool, AsteroidType asteroidType)
    {
        _pool = pool;
        _asteroidType = asteroidType;
    }

    public void ReturnToPool()
    {
        _pool.Release(this);
    }

    public void Hide()
    {
        HideRequest?.Invoke();
    }

    public void Show(Vector3 position, Vector3 velocity)
    {
        ShowRequest?.Invoke(position, velocity);
    }

    public void RequestDestroy()
    {
        DestroyRequest?.Invoke();
    }

    public void ReportBulletCollision()
    {
        BulletCollisionReported?.Invoke(this);
    }

    public Vector3 GetPosition()
    {
        return PositionRequest.Invoke();
    }
}
