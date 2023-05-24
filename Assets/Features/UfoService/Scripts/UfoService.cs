using System.Threading;
using UnityEngine;

public class UfoService
{
    private readonly IPlayerToPlayfieldMessaging _playerMessaging;

    private const float UfoSpawnDelay = 1f;

    private readonly IOutOfScreenPlacementService _outOfScreenPlacementService;

    private bool _isUfoSpawned;

    public UfoService(IOutOfScreenPlacementService outOfScreenPlacementService, IPlayerToPlayfieldMessaging playerMessaging)
    {
        _playerMessaging = playerMessaging;
        _outOfScreenPlacementService = outOfScreenPlacementService;
    }

    public async Awaitable Execute(CancellationToken token)
    {
        var facade = new UfoFacade(_playerMessaging);

        var ufoMessaging = facade.Spawn();

        while (!token.IsCancellationRequested)
        {
            await Awaitable.WaitForSecondsAsync(UfoSpawnDelay, token);

            if(token.IsCancellationRequested)
            {
                break;
            }

            TrySpawn(ufoMessaging);
        }

    }

    private void TrySpawn(IUfoToPlayfieldMessaging ufo)
    {
        if (!_isUfoSpawned)
        {
            _isUfoSpawned = true;

            var position = _outOfScreenPlacementService.GetRandomPositionAtScreenBorder();

            ufo.Show(position);

            ufo.CollisionEvent += OnCollisionEvent;
        }
    }

    private void OnCollisionEvent(IUfoToPlayfieldMessaging ufo)
    {
        _isUfoSpawned = false;

        ufo.CollisionEvent -= OnCollisionEvent;

        ufo.Hide();
    }
}
