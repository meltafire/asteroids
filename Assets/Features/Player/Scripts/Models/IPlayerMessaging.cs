using System;

public interface IPlayerMessaging
{
    event Action SpawnRequest;
    event Func<IPlayerShotSpawnDataProvider> PlayerShotSpawnDataRequest;
}
