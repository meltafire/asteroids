using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletService
{
    private readonly BulletFireInput _input;
    private readonly BulletFacade _facade;

    private bool _isPrewarmed;

    public BulletService(IPlayerShotSpawnDataProvider shotSpawnDataProvider)
    {
        _facade = new BulletFacade(shotSpawnDataProvider);
        _input = new BulletFireInput();
    }

    public void StartService()
    {
        if (!_isPrewarmed)
        {
            _facade.Prewarm();

            _isPrewarmed = true;
        }

        _input.Enable();

        _input.Bullet.FireBullet.started += OnFireBulletStarted;
        _input.Bullet.FireBullet.canceled += OnFireBulletPerformed;
    }

    public void StopService()
    {
        _input.Bullet.FireBullet.started -= OnFireBulletStarted;
        _input.Bullet.FireBullet.canceled -= OnFireBulletPerformed;

        _input.Disable();
    }

    private void OnFireBulletStarted(InputAction.CallbackContext context)
    {
            Fire();
    }

    private void OnFireBulletPerformed(InputAction.CallbackContext context)
    {
    }

    private void Fire()
    {
        _facade.SpawnBullet();
    }
}
