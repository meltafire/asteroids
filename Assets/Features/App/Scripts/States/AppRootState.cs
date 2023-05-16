using System.Threading;
using UnityEngine;

public class AppRootState
{
    private readonly RectTransform _canvasTransform;

    public AppRootState(RectTransform canvasTransform)
    {
        _canvasTransform = canvasTransform;
    }

    public Awaitable Execute(CancellationToken token)
    {
        var stateMachine = new AppStateMachine(_canvasTransform);

        return stateMachine.GoThroughStates(token);
    }
}
