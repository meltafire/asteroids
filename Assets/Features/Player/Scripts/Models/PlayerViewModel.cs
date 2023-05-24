﻿using UnityEngine;

public class PlayerViewModel : IPlayerShotSpawnDataProvider
{
    private const int RotationSpeed = 100;
    private const float SqrSpeedLimit = 10f;

    private readonly PlayerView _playerView;

    private Vector3 _velocity = Vector3.zero;

    public Vector3 Velocity => _velocity;
    public Vector3 ShotStartPosition => _playerView.ShotStartPosition;
    public Vector3 Direction => _playerView.ForwardDirection;

    public Transform ShotStartTransform => _playerView.ShotStartTransform;

    public PlayerViewModel(PlayerView playerView)
    {
        _playerView = playerView;
    }

    public void SpawnPlayer()
    {
        _playerView.Spawn();
    }

    public void TurnLeft()
    {
        _playerView.Rotate(Vector3.forward * RotationSpeed * Time.deltaTime);
    }

    public void TurnRight()
    {
        _playerView.Rotate(-Vector3.forward * RotationSpeed * Time.deltaTime);
    }

    public void Accelerate()
    {
        var expectedVelocity = _velocity + _playerView.ForwardDirection * Time.deltaTime;

        if (expectedVelocity.sqrMagnitude <= SqrSpeedLimit)
        {
            _velocity = expectedVelocity;
        }
    }

    public void Move(Vector3 position)
    {
        _playerView.Move(position);
    }
}
