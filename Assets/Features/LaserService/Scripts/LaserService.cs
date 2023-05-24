using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserService
{
    private const float LaserShowTime = .5f;

    private readonly LaserInput _input;
    private readonly LaserFacade _facade;

    private ILaserToPlayfieldMessaging _laserMessaging;
    private CancellationTokenSource _cts;

    public LaserService()
    {
        _input = new LaserInput();
        _facade = new LaserFacade();
    }

    public void SpawnLaser(Transform parentTransform, IBulletCollisionService collisionService)
    {
        _laserMessaging = _facade.SpawnLaser(parentTransform, collisionService);
    }

    public void StartHandleInput()
    {
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

    private void OnFireStarted(InputAction.CallbackContext context)
    {
        Fire();
    }

    private async Awaitable Fire()
    {
        _laserMessaging.Show();

        await Awaitable.WaitForSecondsAsync(LaserShowTime, _cts.Token);

        _laserMessaging.Hide();
    }
}
