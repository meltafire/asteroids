using System;
using UnityEngine;

public interface IPlayerToPlayfieldMessaging
{
    event Action<Vector3, float, float> ShowHappen;
    event Action HideHappen;
    event Action<Vector3> UpdatePosition;
    event Action CollisionHappened;
    event Action<float> UpdateRotation;
    event Action<float> UpdateSpeed;

    IPlayerShotSpawnDataProvider GetShotSpawnData();
    void Show();
    void Hide();
}
