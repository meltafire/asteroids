using System;

public class PlayerMessaging : IPlayerMessaging, IPlayerToPlayfieldMessaging
{
    public event Action SpawnRequest;
    public event Func<IPlayerShotSpawnDataProvider> PlayerShotSpawnDataRequest;

    public IPlayerShotSpawnDataProvider GetShotSpawnData()
    {
        return PlayerShotSpawnDataRequest?.Invoke();
    }

    public void SpawnPlayer()
    {
        SpawnRequest?.Invoke();
    }
}
