using UnityEngine;

public class PlayerShotSpawnDataProvider : IPlayerShotSpawnDataProvider
{
    private readonly Transform _shotStartTransform;

    public PlayerShotSpawnDataProvider(Transform shotStartTransform)
    {
        _shotStartTransform = shotStartTransform;
    }

    public Transform ShotStartTransform => _shotStartTransform;

    public Vector3 ShotStartPosition => _shotStartTransform.position;

    public Vector3 Direction => _shotStartTransform.up;
}
