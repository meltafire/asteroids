using System.Threading;
using UnityEngine;

public class GameSessionGameState : StateWithTask
{
    private readonly IPlayerToPlayfieldMessaging _playerMessaging;

    public GameSessionGameState(
        IPlayerToPlayfieldMessaging playerMessaging,
        IStateWithTaskConditionProvider conditionProvider)
        : base(conditionProvider)
    {
        _playerMessaging = playerMessaging;
    }

    public override Awaitable Execute(CancellationToken token)
    {
        _playerMessaging.SpawnPlayer();

        return base.Execute(token);
    }
}
