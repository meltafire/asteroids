using System;

public class BulletViewPresenter : IDisposable
{
    private readonly BulletViewModel _model;
    private readonly IBulletMessaging _messaging;
    private readonly IPlayerShotSpawnDataProvider _shotSpawnDataProvider;

    public BulletViewPresenter(IBulletMessaging messaging, BulletViewModel model, IPlayerShotSpawnDataProvider shotSpawnDataProvider)
    {
        _model = model;
        _messaging = messaging;
        _shotSpawnDataProvider = shotSpawnDataProvider;
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

    public void OnUpdate()
    {
        _model.Move();
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
