using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AsteroidsService : ISpawnAsteroidsService
{
    private const int SmallAsteroidPerBigAsteroidLimit = 3;
    private const int BigAsteroidLimit = 5;
    private const float DelayBetweenSpawn = 2f;

    private readonly AsteroidsFacade _asteroidsFacade;
    private readonly IOutOfScreenPlacementService _outOfScreenPlacementService;

    private int _bigActiveAsteroids;

    public AsteroidsService(ILoopPlacementService loopPlacementService, IOutOfScreenPlacementService outOfScreenPlacementService)
    {
        _outOfScreenPlacementService = outOfScreenPlacementService;

        _asteroidsFacade = new AsteroidsFacade(loopPlacementService);
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

            if (_bigActiveAsteroids < BigAsteroidLimit)
            {
                var asteroidMessaging = _asteroidsFacade.SpawnAsteroid(AsteroidType.Big);

                asteroidMessaging.Show(_outOfScreenPlacementService.GetRandomPositionAtScreenBorder());
                asteroidMessaging.BulletCollisionReported += OnBulletCollisionReported;

                _bigActiveAsteroids++;
            }

        }
    }

    private void OnBulletCollisionReported(IAsteroidToPlayfieldMessaging messaging)
    {
        if (messaging.AsteroidType == AsteroidType.Big)
        {
            SpawnSmallAsteroid(messaging);

            _bigActiveAsteroids--;
        }

        messaging.BulletCollisionReported -= OnBulletCollisionReported;
        messaging.ReturnToPool();
    }

    private void SpawnSmallAsteroid(IAsteroidToPlayfieldMessaging messaging)
    {
        for (int i = 0; i < SmallAsteroidPerBigAsteroidLimit; i++)
        {
            var asteroidMessaging = _asteroidsFacade.SpawnAsteroid(AsteroidType.Small);

            asteroidMessaging.Show(messaging.GetPosition());
            asteroidMessaging.BulletCollisionReported += OnBulletCollisionReported;
        }
    }
}
