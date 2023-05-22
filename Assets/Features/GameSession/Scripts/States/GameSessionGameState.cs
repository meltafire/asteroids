using System.Threading;
using UnityEngine;

public class GameSessionGameState : StateWithTask
{
    private readonly IPlayerToPlayfieldMessaging _playerMessaging;
    private readonly ISpawnAsteroidsService _asteroidsService;
    private readonly BulletService _bulletService;

    public GameSessionGameState(
        IPlayerToPlayfieldMessaging playerMessaging,
        ISpawnAsteroidsService asteroidsService,
        BulletService bulletService,
        IStateWithTaskConditionProvider conditionProvider)
        : base(conditionProvider)
    {
        _playerMessaging = playerMessaging;
        _asteroidsService = asteroidsService;
        _bulletService = bulletService;
    }

    public async override Awaitable Execute(CancellationToken token)
    {
        _playerMessaging.SpawnPlayer();

        _bulletService.StartService();

        using (var linkedTs = CancellationTokenSource.CreateLinkedTokenSource(token))
        {
            _asteroidsService.SpawnAsteroids(linkedTs.Token);

            await base.Execute(token);

            linkedTs.Cancel();
        }

        _bulletService.StopService();
    }
}
