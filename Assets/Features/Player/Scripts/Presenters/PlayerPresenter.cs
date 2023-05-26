using System;
using UnityEngine;

public class PlayerPresenter : IDisposable
{
    private readonly IPlayerMessaging _playerMessaging;
    private readonly ILoopPlacementService _loopPlacementService;
    private readonly PlayerViewModel _model;
    private readonly PlayerMovementnput _input;
    private readonly ICollisionService _collisionService;

    private IPlayerShotSpawnDataProvider _shotSpawnDataProvider;

    public PlayerPresenter(ICollisionService collisionService, IPlayerMessaging playerMessaging, ILoopPlacementService loopPlacementService, PlayerViewModel model)
    {
        _playerMessaging = playerMessaging;
        _loopPlacementService = loopPlacementService;
        _model = model;
        _collisionService = collisionService;

        _input = new PlayerMovementnput();
    }

    public void Dispose()
    {
        _playerMessaging.ShowRequest -= OnShowRequested;
        _playerMessaging.HideRequest -= OnHideRequested;
        _playerMessaging.PlayerShotSpawnDataRequest -= OnPlayerShotSpawnDataRequest;

        _input.Disable();
    }

    public void OnViewCreated()
    {
        _playerMessaging.ShowRequest += OnShowRequested;
        _playerMessaging.HideRequest += OnHideRequested;
        _playerMessaging.PlayerShotSpawnDataRequest += OnPlayerShotSpawnDataRequest;

        _shotSpawnDataProvider = new PlayerShotSpawnDataProvider(_model.ShotStartTransform);
    }

    public void OnColliderTrigger(Collider2D col)
    {
        var wasCollision = _collisionService.HandleCollision(col);

        if (wasCollision)
        {
            _playerMessaging.ReportCollision();
        }
    }

    private void OnShowRequested()
    {
        _model.Show();

        _input.Enable();

        _playerMessaging.ReportShowHappen(_model.Position, _model.Rotation, _model.Speed);
    }

    private void OnHideRequested()
    {
        _input.Disable();

        _model.Hide();

        _playerMessaging.ReportHideHappen();
    }

    public void OnUpdate()
    {
        HandleAcceleration();
        HandleRotation();

        var expectedPosition = _loopPlacementService.AdjustPosition(_model.Velocity * Time.deltaTime + _model.Position);

        _model.Move(expectedPosition);

        _playerMessaging.ReportUpdatePosition(_model.Position);
    }

    private void HandleRotation()
    {
        var rotationAxis = _input.Movement.Rotate.ReadValue<float>();

        if (rotationAxis != 0)
        {
            if (rotationAxis < 0)
            {
                _model.TurnLeft();
            }
            else
            {
                _model.TurnRight();
            }

            _playerMessaging.ReportUpdateRotation(_model.Rotation);
        }
    }

    private void HandleAcceleration()
    {
        var movementIndex = _input.Movement.Move.ReadValue<float>();

        if (movementIndex != 0)
        {
            _model.Accelerate();

            _playerMessaging.ReportSpeedUpdate(_model.Speed);
        }
    }

    private IPlayerShotSpawnDataProvider OnPlayerShotSpawnDataRequest()
    {
        return _shotSpawnDataProvider;
    }
}
