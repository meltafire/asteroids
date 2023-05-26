using System;
using UnityEngine;

public class PlayerMessaging : IPlayerMessaging, IPlayerToPlayfieldMessaging
{
    public event Action ShowRequest;
    public event Action HideRequest;
    public event Func<IPlayerShotSpawnDataProvider> PlayerShotSpawnDataRequest;
    public event Action CollisionHappened;
    public event Action<Vector3, float> ShowHappen;
    public event Action HideHappen;
    public event Action<Vector3> UpdatePosition;
    public event Action<float> UpdateRotation;

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

    public void ReportShowHappen(Vector3 position, float rotation)
    {
        ShowHappen?.Invoke(position, rotation);
    }

    public void ReportHideHappen()
    {
        HideHappen?.Invoke();
    }

    public void ReportUpdatePosition(Vector3 position)
    {
        UpdatePosition?.Invoke(position);
    }

    public void ReportUpdateRotation(float rotation)
    {
        UpdateRotation?.Invoke(rotation);
    }
}
