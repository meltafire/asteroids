using System.Threading;
using UnityEngine;

public class AppController
{
    public async Awaitable Execute(RectTransform canvasTransform, CancellationToken token)
    {
        var stateMachine = new StateMachine(canvasTransform);

        var state = stateMachine.GetNextState();

        while (state != null && !token.IsCancellationRequested)
        {
            await state.Execute(token);

            state = stateMachine.GetNextState();
        }
    }
}
