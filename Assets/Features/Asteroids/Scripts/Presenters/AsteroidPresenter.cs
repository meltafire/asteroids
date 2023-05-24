using System;
using UnityEngine;

public class AsteroidPresenter : IDisposable
{
    private readonly IAsteroidMessaging _messaging;
    private readonly AsteroidViewModel _model;
    private readonly ILoopPlacementService _loopPlacementService;

    public AsteroidPresenter(
        IAsteroidMessaging messaging,
        AsteroidViewModel model,
        ILoopPlacementService loopPlacementService)
    {
        _messaging = messaging;
        _model = model;
        _loopPlacementService = loopPlacementService;
    }

    public void OnViewCreated()
    {
        _messaging.ShowRequest += OnShowRequested;
        _messaging.HideRequest += OnHideRequested;
        _messaging.DestroyRequest += OnDestroyRequested;
        _messaging.PositionRequest += OnPositionRequested;
    }

    public void Dispose()
    {
        _messaging.ShowRequest -= OnShowRequested;
        _messaging.HideRequest -= OnHideRequested;
        _messaging.DestroyRequest -= OnDestroyRequested;
        _messaging.PositionRequest -= OnPositionRequested;
    }

    public void OnUpdate(Vector3 position)
    {
        var expectedPosition = _loopPlacementService.AdjustPosition(_model.Velocity * Time.deltaTime + position);

        _model.Move(expectedPosition);
    }

    public void OnBulletCollision()
    {
        _messaging.ReportBulletCollision();
    }

    private void OnDestroyRequested()
    {
        _model.HandleDestroy();
    }

    private void OnShowRequested(Vector3 position)
    {
        _model.HandleShow(position);
    }

    private void OnHideRequested()
    {
        _model.HandleHide();
    }

    private Vector3 OnPositionRequested()
    {
        return _model.Position;
    }
}
