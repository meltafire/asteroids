using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserService : IDisposable
{
    private const float LaserShowTime = .5f;

    private readonly LaserServiceExternalMessaging _laserServiceExternalMessaging;
    private readonly LaserInput _input;
    private readonly LaserFacade _facade;
    private readonly LaserServiceModel _model;

    private ILaserToPlayfieldMessaging _laserMessaging;
    private CancellationTokenSource _cts;

    public ILaserServiceExternalMessaging LaserServiceExternalMessaging => _laserServiceExternalMessaging;

    public LaserService()
    {
        _input = new LaserInput();
        _facade = new LaserFacade();
        _model = new LaserServiceModel();
        _laserServiceExternalMessaging = new LaserServiceExternalMessaging();
    }

    public void SpawnLaser(Transform parentTransform, ICollisionService collisionService)
    {
        _laserMessaging = _facade.SpawnLaser(parentTransform, collisionService);
    }

    public void Initialize()
    {
        _laserServiceExternalMessaging.ShotCountRequested += OnShotCountRequested;
        _laserServiceExternalMessaging.TimeRequested += OnTimeRequested;

        _model.ShotCountChanged += OnModelShotCountChanged;
        _model.TimeChanged += OnModelTimeChanged;
    }

    public void StartHandleInput()
    {
        _model.Reset();

        _cts = new CancellationTokenSource();

        _input.Enable();

        _input.Laser.Fire.started += OnFireStarted;
    }

    public void StopHandleInput()
    {
        _cts.Cancel();

        _input.Laser.Fire.started -= OnFireStarted;

        _input.Disable();
    }

    public void Dispose()
    {
         _laserServiceExternalMessaging.ShotCountRequested -= OnShotCountRequested;
        _laserServiceExternalMessaging.TimeRequested -= OnTimeRequested;

        _model.ShotCountChanged -= OnModelShotCountChanged;
        _model.TimeChanged -= OnModelTimeChanged;
    }

    private void OnFireStarted(InputAction.CallbackContext context)
    {
        if (_model.CurrentLazerCount > 0)
        {
            _model.Use();

            Fire();

            TryRefill();
        }
    }

    private async Awaitable Fire()
    {
        _laserMessaging.Show();

        await Awaitable.WaitForSecondsAsync(LaserShowTime, _cts.Token);

        _laserMessaging.Hide();
    }

    private async Awaitable TryRefill()
    {
        if (!_model.IsRefillOngoing && _model.CurrentLazerCount < LaserServiceModel.LazerLimit)
        {
            _model.DeclareRefill();

            while (_model.IsRefillOngoing)
            {
                await Awaitable.NextFrameAsync();

                if (_cts.Token.IsCancellationRequested)
                {
                    return;
                }

                _model.AwateHappened(Time.deltaTime);
            }
        }

    }

    private float OnTimeRequested()
    {
        return _model.TimeToRefill;
    }

    private int OnShotCountRequested()
    {
        return _model.CurrentLazerCount;
    }

    private void OnModelTimeChanged(float time)
    {
        _laserServiceExternalMessaging.ReportTime(time);
    }

    private void OnModelShotCountChanged(int count)
    {
        _laserServiceExternalMessaging.ReportShotCount(count);
    }
}
