using System;
using UnityEngine;

public interface IPlayerToPlayfieldMessaging
{
    event Action<Vector3> ShowHappen;
    event Action HideHappen;
    event Action<Vector3> UpdatePosition;
    event Action CollisionHappened;

    IPlayerShotSpawnDataProvider GetShotSpawnData();
    void Show();
    void Hide();
}
