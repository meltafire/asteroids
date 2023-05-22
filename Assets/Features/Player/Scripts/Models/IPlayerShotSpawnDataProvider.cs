using UnityEngine;

public interface IPlayerShotSpawnDataProvider
{
    Vector3 ShotStartPosition { get; }
    Vector3 Direction { get; }
}
