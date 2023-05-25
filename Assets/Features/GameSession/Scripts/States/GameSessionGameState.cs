using System.Threading;
using UnityEngine;

public class GameSessionGameState : StateWithTask
{
    private readonly IPlayerToPlayfieldMessaging _playerMessaging;
    private readonly ISpawnAsteroidsService _asteroidsService;
    private readonly BulletService _bulletService;
    private readonly LaserService _laserService;
    private readonly UfoService _ufoService;
    private readonly GameSessionMessaging _gameMessaging;

    public GameSessionGameState(
        IPlayerToPlayfieldMessaging playerMessaging,
        ISpawnAsteroidsService asteroidsService,
        BulletService bulletService,
        LaserService laserService,
        UfoService ufoService,
        GameSessionMessaging gameMessaging)
        : base(gameMessaging)
    {
        _gameMessaging = gameMessaging;
        _playerMessaging = playerMessaging;
        _asteroidsService = asteroidsService;
        _bulletService = bulletService;
        _laserService = laserService;
        _ufoService = ufoService;
    }

    public async override Awaitable Execute(CancellationToken token)
    {
        using (var linkedTs = CancellationTokenSource.CreateLinkedTokenSource(token))
        {
            var linkedToken = linkedTs.Token;

            _playerMessaging.Show();
            _playerMessaging.CollisionHappened += _gameMessaging.RequestGameEnd;

            _asteroidsService.SpawnAsteroids(linkedToken);

            _bulletService.StartHandleInput();
            _laserService.StartHandleInput();

            _ufoService.Execute(linkedToken);

            await base.Execute(token);

            _playerMessaging.CollisionHappened -= _gameMessaging.RequestGameEnd;
            _playerMessaging.Hide();

            linkedTs.Cancel();

            _bulletService.StopHandleInput();
            _laserService.StopHandleInput();
        }
    }
}
