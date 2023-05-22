using UnityEngine;

public interface IBulletSpawnDataProvider
{
    Vector3 StartPosition { get; }
    Vector3 Direction { get; }
    float InitialSpeed { get; }
}
