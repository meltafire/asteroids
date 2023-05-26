using System;
using UnityEngine;

public class PlayerMessaging : IPlayerMessaging, IPlayerToPlayfieldMessaging
{
    public event Action ShowRequest;
    public event Action HideRequest;
    public event Func<IPlayerShotSpawnDataProvider> PlayerShotSpawnDataRequest;
    public event Action CollisionHappened;
    public event Action<Vector3, float, float> ShowHappen;
    public event Action HideHappen;
    public event Action<Vector3> UpdatePosition;
    public event Action<float> UpdateRotation;
    public event Action<float> UpdateSpeed;

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

    public void ReportShowHappen(Vector3 position, float rotation, float speed)
    {
        ShowHappen?.Invoke(position, rotation, speed);
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

    public void ReportSpeedUpdate(float speed)
    {
        UpdateSpeed?.Invoke(speed);
    }
}
