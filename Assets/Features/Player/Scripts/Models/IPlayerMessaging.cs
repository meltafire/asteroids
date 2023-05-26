using System;
using UnityEngine;

public interface IPlayerMessaging
{
    event Action ShowRequest;
    event Action HideRequest;
    event Func<IPlayerShotSpawnDataProvider> PlayerShotSpawnDataRequest;

    void ReportCollision();
    void ReportShowHappen(Vector3 position, float rotation);
    void ReportHideHappen();
    void ReportUpdatePosition(Vector3 position);
    void ReportUpdateRotation(float rotation);
}
