using System;
using UnityEngine;

public interface IAsteroidToPlayfieldMessaging
{
    event Action<IAsteroidToPlayfieldMessaging> BulletCollisionReported;

    AsteroidType AsteroidType { get; }

    Vector3 GetPosition();
    void Show(Vector3 position);
    void ReturnToPool();
}
