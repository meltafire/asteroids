using UnityEngine.Pool;

public class AsteroidMessaging : IAsteroidToPlayfieldMessaging
{
    private readonly IObjectPool<AsteroidMessaging> _pool;

    public AsteroidMessaging(IObjectPool<AsteroidMessaging> pool)
    {
        _pool = pool;
    }

    public void ReturnToPool()
    {
        _pool.Release(this);
    }

    public void Show()
    {
        
    }

    public void RequestDestroy()
    {

    }
}
