using System;
using UnityEngine;

public class PlayerMessaging : IPlayerMessaging, IPlayerToPlayfieldMessaging
{
    public event Action ShowRequest;
    public event Action HideRequest;
    public event Func<IPlayerShotSpawnDataProvider> PlayerShotSpawnDataRequest;
    public event Action CollisionHappened;
    public event Action<Vector3> ShowHappen;
    public event Action HideHappen;
    public event Action<Vector3> UpdatePosition;

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

    public void ReportShowHappen(Vector3 position)
    {
        ShowHappen?.Invoke(position);
    }

    public void ReportHideHappen()
    {
        HideHappen?.Invoke();
    }

    public void ReportUpdatePosition(Vector3 position)
    {
        UpdatePosition?.Invoke(position);
    }
}
