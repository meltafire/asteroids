using UnityEngine;

public class PlayerViewModel
{
    private const int RotationSpeed = 100;
    private const float MovementSpeed = .05f;
    private const float SqrSpeedLimit = 10f;

    private readonly PlayerView _playerView;

    private Vector3 _velocity = Vector3.zero;

    public Vector3 Velocity => _velocity;

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
        var expectedVelocity = _velocity + _playerView.ForwardDirection * MovementSpeed * Time.deltaTime;

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
