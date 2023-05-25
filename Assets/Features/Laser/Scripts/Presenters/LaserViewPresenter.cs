using System;
using UnityEngine;

public class LaserViewPresenter : IDisposable
{
    private readonly LaserViewModel _model;
    private readonly ILaserMessaging _messaging;
    private readonly ICollisionService _collisionService;

    public LaserViewPresenter(LaserViewModel model, ILaserMessaging messaging, ICollisionService collisionService)
    {
        _model = model;
        _messaging = messaging;
        _collisionService = collisionService;
    }

    public void Dispose()
    {
        _messaging.HideRequest += OnHideRequest;
        _messaging.ShowRequest += OnShowRequest;
    }

    public void OnViewCreated()
    {
        _messaging.HideRequest += OnHideRequest;
        _messaging.ShowRequest += OnShowRequest;
    }

    public void OnColliderTrigger(Collider2D col)
    {
        _collisionService.HandleCollision(col);
    }

    private void OnShowRequest()
    {
        _model.Show();
    }

    private void OnHideRequest()
    {
        _model.Hide();
    }
}
