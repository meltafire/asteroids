using System;

public class PlayerMessaging : IPlayerMessaging, IPlayerToPlayfieldMessaging
{
    public event Action ShowRequest;
    public event Action HideRequest;
    public event Func<IPlayerShotSpawnDataProvider> PlayerShotSpawnDataRequest;
    public event Action CollisionHappened;

    public IPlayerShotSpawnDataProvider GetShotSpawnData()
    {
        return PlayerShotSpawnDataRequest?.Invoke();
    }

    public void ReportCollision()
    {
        CollisionHappened?.Invoke();
    }

    public void Show()
    {
        ShowRequest?.Invoke();
    }

    public void Hide()
    {
        HideRequest?.Invoke();
    }
}
