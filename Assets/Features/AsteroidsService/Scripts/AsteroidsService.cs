using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AsteroidsService : ISpawnAsteroidsService, IDespawnAsteroidsService
{
    private const int SmallAsteroidPerBigAsteroidLimit = 3;
    private const int BigAsteroidLimit = 5;
    private const float DelayBetweenSpawn = 2f;
    private const int InitalCacheSize = 20;

    private readonly AsteroidsFacade _asteroidsFacade;
    private readonly IOutOfScreenPlacementService _outOfScreenPlacementService;

    private int _bigActiveAsteroids;

    private List<IAsteroidToPlayfieldMessaging> _bigAsteroids = new List<IAsteroidToPlayfieldMessaging>(InitalCacheSize);
    private List<IAsteroidToPlayfieldMessaging> _smallAsteroids = new List<IAsteroidToPlayfieldMessaging>(InitalCacheSize);

    public AsteroidsService(ILoopPlacementService loopPlacementService, IOutOfScreenPlacementService outOfScreenPlacementService)
    {
        _outOfScreenPlacementService = outOfScreenPlacementService;

        _asteroidsFacade = new AsteroidsFacade(loopPlacementService, InitalCacheSize, InitalCacheSize);
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

                _bigAsteroids.Add(asteroidMessaging);

                _bigActiveAsteroids++;
            }

        }

    }

    public void DespawnAll()
    {
        foreach (var item in _bigAsteroids)
        {
            item.ReturnToPool();
        }

        foreach (var item in _smallAsteroids)
        {
            item.ReturnToPool();
        }

        _smallAsteroids.Clear();
        _bigAsteroids.Clear();
    }

    private void OnBulletCollisionReported(IAsteroidToPlayfieldMessaging messaging)
    {
        if (messaging.AsteroidType == AsteroidType.Big)
        {
            SpawnSmallAsteroid(messaging);

            _bigActiveAsteroids--;

            _bigAsteroids.Remove(messaging);
        }
        else
        {
            _smallAsteroids.Remove(messaging);
        }

        messaging.BulletCollisionReported -= OnBulletCollisionReported;
        messaging.ReturnToPool();
    }

    private void SpawnSmallAsteroid(IAsteroidToPlayfieldMessaging bigAsteroidmMessaging)
    {
        for (int i = 0; i < SmallAsteroidPerBigAsteroidLimit; i++)
        {
            var asteroidMessaging = _asteroidsFacade.SpawnAsteroid(AsteroidType.Small);
            _smallAsteroids.Add(asteroidMessaging);

            asteroidMessaging.Show(bigAsteroidmMessaging.GetPosition());
            asteroidMessaging.BulletCollisionReported += OnBulletCollisionReported;
        }
    }
}
