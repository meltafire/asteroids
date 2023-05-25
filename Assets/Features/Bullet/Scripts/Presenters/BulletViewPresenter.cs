using System;
using UnityEngine;

public class BulletViewPresenter : IDisposable
{
    private readonly BulletViewModel _model;
    private readonly IBulletMessaging _messaging;
    private readonly IPlayerShotSpawnDataProvider _shotSpawnDataProvider;
    private readonly ICollisionService _collisionService;
    private readonly IOutOfScreenCheck _outOfScreenCheck;

    public BulletViewPresenter(
        IBulletMessaging messaging,
        BulletViewModel model,
        IPlayerShotSpawnDataProvider shotSpawnDataProvider,
        ICollisionService collisionService,
        IOutOfScreenCheck outOfScreenCheck)
    {
        _model = model;
        _messaging = messaging;
        _shotSpawnDataProvider = shotSpawnDataProvider;
        _collisionService = collisionService;
        _outOfScreenCheck = outOfScreenCheck;
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
        var isOutOfScreen = _outOfScreenCheck.IsOutOfScreen(position);
        if(isOutOfScreen)
        {
            _messaging.ReportCollision();
        }

        _model.Move();
    }

    public void OnColliderTrigger(Collider2D col)
    {
        var wasCollision = _collisionService.HandleCollision(col);

        if (wasCollision)
        {
            _messaging.ReportCollision();
        }
    }

    private void OnDestroyRequested()
    {
        _model.HandleDestroy();
    }

    private void OnHideRequested()
    {
        _model.HandleHide();
    }

    private void OnShowRequested()
    {
        _model.HandleShow(_shotSpawnDataProvider);
    }
}
