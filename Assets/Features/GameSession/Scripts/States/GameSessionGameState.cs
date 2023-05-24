using System.Threading;
using UnityEngine;

public class GameSessionGameState : StateWithTask
{
    private readonly IPlayerToPlayfieldMessaging _playerMessaging;
    private readonly ISpawnAsteroidsService _asteroidsService;
    private readonly BulletService _bulletService;
    private readonly LaserService _laserService;
    private readonly UfoService _ufoService;

    public GameSessionGameState(
        IPlayerToPlayfieldMessaging playerMessaging,
        ISpawnAsteroidsService asteroidsService,
        BulletService bulletService,
        LaserService laserService,
        UfoService ufoService,
        IStateWithTaskConditionProvider conditionProvider)
        : base(conditionProvider)
    {
        _playerMessaging = playerMessaging;
        _asteroidsService = asteroidsService;
        _bulletService = bulletService;
        _laserService = laserService;
        _ufoService = ufoService;
    }

    public async override Awaitable Execute(CancellationToken token)
    {
        _playerMessaging.SpawnPlayer();

        using (var linkedTs = CancellationTokenSource.CreateLinkedTokenSource(token))
        {
            var linkedToken = linkedTs.Token;

            _asteroidsService.SpawnAsteroids(linkedToken);

            _bulletService.StartHandleInput();
            _laserService.StartHandleInput();

            _ufoService.Execute(linkedToken);

            await base.Execute(token);

            linkedTs.Cancel();

            _bulletService.StopHandleInput();
            _laserService.StopHandleInput();
        }
    }
}
