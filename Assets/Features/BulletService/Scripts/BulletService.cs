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
    private bool _isCooldownOver = true;
    private CancellationTokenSource _cts;

    public BulletService(IPlayerShotSpawnDataProvider shotSpawnDataProvider, IOutOfScreenCheck outOfScreenCheck, ICollisionService collisionService)
    {
        _facade = new BulletFacade(shotSpawnDataProvider, outOfScreenCheck, collisionService);
        _input = new BulletFireInput();
    }

    public void StartHandleInput()
    {
        _cts = new CancellationTokenSource();

        if (!_isPrewarmed)
        {
            _facade.Prewarm();

            _isPrewarmed = true;
        }

        _input.Enable();

        _input.Bullet.FireBullet.started += OnFireBulletStarted;
        _input.Bullet.FireBullet.canceled += OnFireBulletPerformed;
    }

    public void StopHandleInput()
    {
        _cts.Cancel();

        _isCooldownOver = true;
        _isFireOngoing = false;

        _input.Bullet.FireBullet.started -= OnFireBulletStarted;
        _input.Bullet.FireBullet.canceled -= OnFireBulletPerformed;

        _input.Disable();
    }

    private void OnFireBulletStarted(InputAction.CallbackContext context)
    {
        if(!_isFireOngoing)
        {
            _isFireOngoing = true;

            TryFire(_cts.Token);
        }
    }

    private void OnFireBulletPerformed(InputAction.CallbackContext context)
    {
        _isFireOngoing = false;
    }

    private async Awaitable TryFire(CancellationToken token)
    {
        if (_isCooldownOver)
        {
            while (_isFireOngoing && !token.IsCancellationRequested)
            {
                _isCooldownOver = false;

                if (_isFireOngoing)
                {
                    var bullet = _facade.SpawnBullet();

                    HandleBulletDestroy(bullet);

                    await Awaitable.WaitForSecondsAsync(DelaySeconds, token);
                }

                _isCooldownOver = true;
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
