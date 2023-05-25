public class BulletFacade
{
    private readonly BulletPool _bulletPool;

    public BulletFacade(int InitalCacheSize, IPlayerShotSpawnDataProvider shotSpawnDataProvider, IOutOfScreenCheck outOfScreenCheck, ICollisionService bulletCollisionService)
    {
        var factory = new BulletFactory();

        _bulletPool = new BulletPool(InitalCacheSize, factory, shotSpawnDataProvider, bulletCollisionService, outOfScreenCheck);
    }

    public void Prewarm()
    {
        _bulletPool.Prewarm();
    }

    public IBulletToPlayfieldMessaging SpawnBullet()
    {
        return _bulletPool.Get();
    }
}
