using System.Threading;
using UnityEngine;

public class GameSessionRootState
{
    public async Awaitable Execute(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            var gameSessionAndPlayerMessaging = new GameSessionAndPlayerMessaging();

            var stateMachine = new GameSessionStateMachine(gameSessionAndPlayerMessaging);

            await stateMachine.GoThroughStates(token);
        }
    }
}