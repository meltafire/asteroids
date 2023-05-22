using System;
using UnityEngine;

public class PlayerPresenter : IDisposable
{
    private readonly IPlayerMessaging _playerMessaging;
    private readonly ILoopPlacementService _loopPlacementService;
    private readonly PlayerViewModel _model;
    private readonly PlayerMovementnput _input;

    public PlayerPresenter(IPlayerMessaging playerMessaging, ILoopPlacementService loopPlacementService, PlayerViewModel model)
    {
        _playerMessaging = playerMessaging;
        _loopPlacementService = loopPlacementService;
        _model = model;

        _input = new PlayerMovementnput();
    }

    public void Dispose()
    {
        _playerMessaging.SpawnRequest -= OnSpawnRequested;
        _playerMessaging.PlayerShotSpawnDataRequest -= OnPlayerShotSpawnDataRequest;

        _input.Disable();
    }

    public void OnViewCreated()
    {
        _playerMessaging.SpawnRequest += OnSpawnRequested;
        _playerMessaging.PlayerShotSpawnDataRequest += OnPlayerShotSpawnDataRequest;
    }

    private void OnSpawnRequested()
    {
        _model.SpawnPlayer();

        _input.Enable();
    }

    public void OnUpdate(Vector3 position)
    {
        HandleAcceleration();
        HandleRotation();

        var expectedPosition = _loopPlacementService.AdjustPosition(_model.Velocity * Time.deltaTime + position);

        _model.Move(expectedPosition);
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
        }
    }

    private void HandleAcceleration()
    {
        var movementIndex = _input.Movement.Move.ReadValue<float>();

        if (movementIndex != 0)
        {
            _model.Accelerate();
        }
    }

    private IPlayerShotSpawnDataProvider OnPlayerShotSpawnDataRequest()
    {
        return _model;
    }
}
