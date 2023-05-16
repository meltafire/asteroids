using System.Threading;
using UnityEngine;

public class GameSessionController
{
    public async Awaitable Execute(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            var stateMachine = new GameSessionStateMachine();

            await stateMachine.GoThroughStates(token);
        }
    }
}
