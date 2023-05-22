using System.Threading;
using UnityEngine;

public interface ISpawnAsteroidsService
{
    Awaitable SpawnAsteroids(CancellationToken token);
}
