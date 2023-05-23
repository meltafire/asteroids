public class BulletFacade
{
    private readonly BulletPool _bulletPool;

    public BulletFacade(IPlayerShotSpawnDataProvider shotSpawnDataProvider, IOutOfScreenCheck outOfScreenCheck)
    {
        var factory = new BulletFactory();
        var collisionService = new BulletCollisionService();

        _bulletPool = new BulletPool(20, factory, shotSpawnDataProvider, collisionService, outOfScreenCheck);
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
