using System.Threading;
using UnityEngine;

public class AppController
{
    public Awaitable Execute(RectTransform canvasTransform, CancellationToken token)
    {
        var stateMachine = new AppStateMachine(canvasTransform);

        return stateMachine.GoThroughStates(token);
    }
}
