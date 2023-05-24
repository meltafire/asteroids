using System;
using UnityEngine;

public class TriggerView : MonoBehaviour
{
    public event Action TriggerHappened;

    public void HandleBulletCollision()
    {
        TriggerHappened?.Invoke();
    }
}
