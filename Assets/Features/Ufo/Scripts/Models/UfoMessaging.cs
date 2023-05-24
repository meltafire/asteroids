using System;
using UnityEngine;

public class UfoMessaging : IUfoMessaging, IUfoToPlayfieldMessaging
{
    public event Action<IUfoToPlayfieldMessaging> CollisionEvent;
    public event Action<Vector3> ShowRequested;
    public event Action HideRequested;

    public void Hide()
    {
        HideRequested?.Invoke();
    }

    public void ReportCollisionEvent()
    {
        CollisionEvent?.Invoke(this);
    }

    public void Show(Vector3 position)
    {
        ShowRequested?.Invoke(position);
    }
}
