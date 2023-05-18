public class AsteroidsFacade
{
    private readonly AsteroidsPool _smallAsteroidsPool;
    private readonly AsteroidsPool _bigAsteroidsPool;

    public AsteroidsFacade()
    {
        var factory = new AsteroidViewFactory();

        _smallAsteroidsPool = new AsteroidsPool(20, factory, AsteroidType.Small);
        _bigAsteroidsPool = new AsteroidsPool(20, factory, AsteroidType.Big);
    }

    public IAsteroidToPlayfieldMessaging SpawnAsteroid(AsteroidType asteroidType)
    {
        if (asteroidType == AsteroidType.Big)
        {
            return _bigAsteroidsPool.GetMessaging();
        }
        else
        {
            return _smallAsteroidsPool.GetMessaging();
        }
    }
}
