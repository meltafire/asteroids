using System;
using UnityEngine;

public class UfoViewPresenter : IDisposable
{
    private readonly UfoModel _model;
    private readonly IUfoMessaging _messaging;
    private readonly IPlayerToPlayfieldMessaging _playerMessaging;

    public UfoViewPresenter(IPlayerToPlayfieldMessaging playerMessaging, UfoModel model, IUfoMessaging messaging)
    {
        _playerMessaging = playerMessaging;
        _model = model;
        _messaging = messaging;
    }

    public void OnViewCreated()
    {
        _messaging.ShowRequested += OnShowRequest;
        _messaging.HideRequested += OnHideRequest;
    }

    public void Dispose()
    {
        _messaging.ShowRequested -= OnShowRequest;
        _messaging.HideRequested -= OnHideRequest;
    }

    public void OnBulletCollision()
    {
        _messaging.ReportCollisionEvent();
    }

    public void OnUpdate()
    {
        _model.Move(_playerMessaging.GetShotSpawnData().ShotStartPosition);
    }

    private void OnHideRequest()
    {
        _model.Hide();
    }

    private void OnShowRequest(Vector3 position)
    {
        _model.Show(position);
    }
}
