using System.Threading;
using UnityEngine;

public class GameSessionGameState : StateWithTask
{
    private readonly IPlayerToPlayfieldMessaging _playerMessaging;
    private readonly ISpawnAsteroidsService _asteroidsService;

    public GameSessionGameState(
        IPlayerToPlayfieldMessaging playerMessaging,
        ISpawnAsteroidsService asteroidsService,
        IStateWithTaskConditionProvider conditionProvider)
        : base(conditionProvider)
    {
        _playerMessaging = playerMessaging;
        _asteroidsService = asteroidsService;
    }

    public async override Awaitable Execute(CancellationToken token)
    {
        _playerMessaging.SpawnPlayer();

        using (var linkedTs = CancellationTokenSource.CreateLinkedTokenSource(token))
        {
            _asteroidsService.SpawnAsteroids(linkedTs.Token);

            await base.Execute(token);

            linkedTs.Cancel();
        }
    }
}
