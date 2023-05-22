using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AsteroidsService : ISpawnAsteroidsService
{
    private const int AsteroidLimit = 5;
    private const float DelayBetweenSpawn = 2f;

    private readonly List<IAsteroidToPlayfieldMessaging> _asteroidsCollection;
    private readonly AsteroidsFacade _asteroidsFacade;

    private int _activeAsteroids;

    public AsteroidsService(ILoopPlacementService loopPlacementService, IOutOfScreenPlacementService outOfScreenPlacementService)
    {
        _asteroidsCollection = new List<IAsteroidToPlayfieldMessaging>();
        _asteroidsFacade = new AsteroidsFacade(loopPlacementService, outOfScreenPlacementService);
    }

    public async Awaitable SpawnAsteroids(CancellationToken token)
    {
        _asteroidsFacade.Prewarm();

        while (!token.IsCancellationRequested)
        {
            await Awaitable.WaitForSecondsAsync(DelayBetweenSpawn, token);

            if (token.IsCancellationRequested)
            {
                return;
            }

            if(_activeAsteroids < AsteroidLimit)
            {
                var asteroidMessaging = _asteroidsFacade.SpawnAsteroid(AsteroidType.Big);

                _asteroidsCollection.Add(asteroidMessaging);

                _activeAsteroids++;
            }

        }
    }
}
