using System.Threading;
using UnityEngine;

public class GameSessionFacade
{
    public Awaitable Execute(RectTransform canvasTransfrom, RectTransform indicatorsCanvasTransfrom, CancellationToken token)
    {
        var controller = new GameSessionRootState(canvasTransfrom, indicatorsCanvasTransfrom);

        return controller.Execute(token);
    }
}
