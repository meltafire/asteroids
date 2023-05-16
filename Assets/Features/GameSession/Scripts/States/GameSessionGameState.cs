using System.Threading;
using UnityEngine;

public class GameSessionGameState : IState
{
    private readonly IGameSessionFromPlayerMessaging _mesasging;

    private AwaitableCompletionSource _completionSource;

    public GameSessionGameState(IGameSessionFromPlayerMessaging mesasging)
    {
        _mesasging = mesasging;
    }

    public async Awaitable Execute(CancellationToken token)
    {
        _completionSource = new AwaitableCompletionSource();
        var tokenRegistration = token.Register(CancelAwaitingForPlayerDestroy);

        _mesasging.OnPlayerDeath += OnConditionMet;

        await _completionSource.Awaitable;

        _mesasging.OnPlayerDeath -= OnConditionMet;

        tokenRegistration.Dispose();
    }

    private void CancelAwaitingForPlayerDestroy()
    {
        _completionSource.TrySetCanceled();
    }

    private void OnConditionMet()
    {
        _completionSource.TrySetResult();
    }
}
