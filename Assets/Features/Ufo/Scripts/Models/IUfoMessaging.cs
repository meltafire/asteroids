using System;
using UnityEngine;

public interface IUfoMessaging
{
    event Action<Vector3> ShowRequested;
    event Action HideRequested;

    void ReportCollisionEvent();
}
