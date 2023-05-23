public class BulletFacade
{
    private readonly BulletPool _bulletPool;

    public BulletFacade(IPlayerShotSpawnDataProvider shotSpawnDataProvider)
    {
        var factory = new BulletFactory();

        _bulletPool = new BulletPool(20, factory, shotSpawnDataProvider);
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
