using System.Threading;
using UnityEngine;

public class AppRootState
{
    public Awaitable Execute(RectTransform canvasTransfrom, RectTransform indicatorsCanvasTransfrom, CancellationToken token)
    {
        var stateMachine = new AppStateMachine(canvasTransfrom, indicatorsCanvasTransfrom);

        return stateMachine.GoThroughStates(token);
    }
}
