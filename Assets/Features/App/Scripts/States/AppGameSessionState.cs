using System.Threading;
using UnityEngine;

public class AppGameSessionState : IState
{
    private readonly RectTransform _canvasTransfrom;
    private readonly RectTransform _indicatorsCanvasTransfrom;

    public AppGameSessionState(RectTransform canvasTransfrom, RectTransform indicatorsCanvasTransfrom)
    {
        _canvasTransfrom = canvasTransfrom;
        _indicatorsCanvasTransfrom = indicatorsCanvasTransfrom;
    }

    public Awaitable Execute(CancellationToken token)
    {
        var facade = new GameSessionFacade();

        return facade.Execute(_canvasTransfrom, _indicatorsCanvasTransfrom, token);
    }
}
