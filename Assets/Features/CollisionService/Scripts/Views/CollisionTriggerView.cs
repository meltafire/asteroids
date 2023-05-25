using System;
using UnityEngine;

public class CollisionTriggerView : MonoBehaviour
{
    public event Action TriggerHappened;

    public void HandleBulletCollision()
    {
        TriggerHappened?.Invoke();
    }
}
