using UnityEngine;

public interface IPlayerShotSpawnDataProvider
{
    Transform ShotStartTransform { get; }
    Vector3 ShotStartPosition { get; }
    Vector3 Direction { get; }
}
