using System.Threading;
using UnityEngine;

public class UfoService : IUfoSpawnService, IUfoDespawnService
{
    private const float UfoSpawnDelay = 1f;

    private readonly IOutOfScreenPlacementService _outOfScreenPlacementService;
    private readonly UfoFacade _ufoFacade;
    private readonly ScoresFacade _scoresFacade;

    private bool _isUfoSpawned;

    private IUfoToPlayfieldMessaging _ufo;

    public UfoService(
        ScoresFacade scoresFacade,
        IOutOfScreenPlacementService outOfScreenPlacementService,
        IPlayerToPlayfieldMessaging playerMessaging)
    {
        _scoresFacade = scoresFacade;
        _outOfScreenPlacementService = outOfScreenPlacementService;
        _ufoFacade = new UfoFacade(playerMessaging);
    }

    public async Awaitable Execute(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Awaitable.WaitForSecondsAsync(UfoSpawnDelay, token);

            if (token.IsCancellationRequested)
            {
                break;
            }

            TrySpawn();
        }

    }

    public void DespawnAll()
    {
        if (_ufo != null)
        {
            _isUfoSpawned = false;
            _ufo.Hide();
        }
    }

    private void TrySpawn()
    {
        if (!_isUfoSpawned)
        {
            if (_ufo == null)
            {
                _ufo = _ufoFacade.Spawn();
            }

            _isUfoSpawned = true;

            var position = _outOfScreenPlacementService.GetRandomPositionAtScreenBorder();

            _ufo.Show(position);


            _ufo.CollisionEvent += OnCollisionEvent;
        }
    }

    private void OnCollisionEvent(IUfoToPlayfieldMessaging ufo)
    {
        _isUfoSpawned = false;

        ufo.CollisionEvent -= OnCollisionEvent;

        _scoresFacade.RegisterUfo();

        ufo.Hide();
    }
}
