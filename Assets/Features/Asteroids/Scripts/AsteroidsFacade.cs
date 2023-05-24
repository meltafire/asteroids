public class AsteroidsFacade
{
    private readonly AsteroidsPool _smallAsteroidsPool;
    private readonly AsteroidsPool _bigAsteroidsPool;

    public AsteroidsFacade(ILoopPlacementService loopPlacementService)
    {
        var factory = new AsteroidViewFactory();

        _smallAsteroidsPool = new AsteroidsPool(20, factory, AsteroidType.Small, loopPlacementService);
        _bigAsteroidsPool = new AsteroidsPool(20, factory, AsteroidType.Big, loopPlacementService);
    }

    public void Prewarm()
    {
        _smallAsteroidsPool.Prewarm();
        _bigAsteroidsPool.Prewarm();
    }

    public IAsteroidToPlayfieldMessaging SpawnAsteroid(AsteroidType asteroidType)
    {
        if (asteroidType == AsteroidType.Big)
        {
            return _bigAsteroidsPool.Get();
        }
        else
        {
            return _smallAsteroidsPool.Get();
        }
    }
}
