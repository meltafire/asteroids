using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletService
{
    private const float DelaySeconds = .5f;

    private readonly BulletFireInput _input;
    private readonly BulletFacade _facade;

    private bool _isPrewarmed;
    private bool _isFireOngoing;

    public BulletService(IPlayerShotSpawnDataProvider shotSpawnDataProvider, IOutOfScreenCheck outOfScreenCheck)
    {
        _facade = new BulletFacade(shotSpawnDataProvider, outOfScreenCheck);
        _input = new BulletFireInput();
    }

    public async Awaitable HandleInput(CancellationToken token)
    {
        if (!_isPrewarmed)
        {
            _facade.Prewarm();

            _isPrewarmed = true;
        }

        _input.Enable();

        _input.Bullet.FireBullet.started += OnFireBulletStarted;
        _input.Bullet.FireBullet.canceled += OnFireBulletPerformed;

        await TryFire(token);

        _input.Bullet.FireBullet.started -= OnFireBulletStarted;
        _input.Bullet.FireBullet.canceled -= OnFireBulletPerformed;

        _input.Disable();
    }

    private void OnFireBulletStarted(InputAction.CallbackContext context)
    {
        _isFireOngoing = true;
    }

    private void OnFireBulletPerformed(InputAction.CallbackContext context)
    {
        _isFireOngoing = false;
    }

    private async Awaitable TryFire(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (_isFireOngoing)
            {
                var bullet = _facade.SpawnBullet();

                HandleBulletDestroy(bullet);

                await Awaitable.WaitForSecondsAsync(DelaySeconds, token);
            }
            else
            {
                await Awaitable.NextFrameAsync(token);
            }

        }

    }

    private void HandleBulletDestroy(IBulletToPlayfieldMessaging messaging)
    {
        messaging.OnCollision += OnCollisionHappened;
    }

    private void OnCollisionHappened(IBulletToPlayfieldMessaging messaging)
    {
        messaging.OnCollision -= OnCollisionHappened;

        messaging.ReturnToPool();
    }
}
