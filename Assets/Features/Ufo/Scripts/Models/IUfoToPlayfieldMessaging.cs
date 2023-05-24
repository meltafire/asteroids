using System;
using UnityEngine;

public interface IUfoToPlayfieldMessaging
{
    event Action<IUfoToPlayfieldMessaging> CollisionEvent;

    void Show(Vector3 position);
    void Hide();
}
