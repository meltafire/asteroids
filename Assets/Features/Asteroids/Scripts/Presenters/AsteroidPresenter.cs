using System;
using UnityEngine;

public class AsteroidPresenter : IDisposable
{
    private readonly IAsteroidMessaging _messaging;
    private readonly AsteroidViewModel _model;
    private readonly ILoopPlacementService _loopPlacementService;
    private readonly IOutOfScreenPlacementService _outOfScreenPlacementService;

    public AsteroidPresenter(
        IAsteroidMessaging messaging,
        AsteroidViewModel model,
        ILoopPlacementService loopPlacementService,
        IOutOfScreenPlacementService outOfScreenPlacementService)
    {
        _messaging = messaging;
        _model = model;
        _loopPlacementService = loopPlacementService;
        _outOfScreenPlacementService = outOfScreenPlacementService;
    }

    public void OnViewCreated()
    {
        _messaging.ShowRequest += OnShowRequested;
        _messaging.HideRequest += OnHideRequested;
        _messaging.DestroyRequest += OnDestroyRequested;
    }

    public void Dispose()
    {
        _messaging.ShowRequest -= OnShowRequested;
        _messaging.HideRequest -= OnHideRequested;
        _messaging.DestroyRequest -= OnDestroyRequested;
    }

    public void OnUpdate(Vector3 position)
    {
        var expectedPosition = _loopPlacementService.AdjustPosition(_model.Velocity * Time.deltaTime + position);

        _model.Move(expectedPosition);
    }

    private void OnDestroyRequested()
    {
        _model.HandleDestroy();
    }

    private void OnShowRequested()
    {
        var position = _outOfScreenPlacementService.GetRandomPositionAtScreenBorder();

        _model.HandleShow(position);
    }

    private void OnHideRequested()
    {
        _model.HandleHide();
    }
}
