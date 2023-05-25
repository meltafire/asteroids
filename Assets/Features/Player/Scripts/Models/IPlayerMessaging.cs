using System;

public interface IPlayerMessaging
{
    event Action ShowRequest;
    event Action HideRequest;
    event Func<IPlayerShotSpawnDataProvider> PlayerShotSpawnDataRequest;

    void ReportCollision();
}
