using System;
using UnityEngine;

public interface IAsteroidMessaging
{
    event Action<Vector3, Vector3> ShowRequest;
    event Action HideRequest;
    event Action DestroyRequest;
    event Func<Vector3> PositionRequest;

    public void ReportBulletCollision();
}
