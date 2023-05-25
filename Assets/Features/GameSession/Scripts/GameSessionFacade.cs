using System.Threading;
using UnityEngine;

public class GameSessionFacade
{
    private readonly RectTransform _canvasTransfrom;
    public GameSessionFacade(RectTransform canvasTransfrom)
    {
        _canvasTransfrom = canvasTransfrom;
    }

    public Awaitable Execute(CancellationToken token)
    {
        var controller = new GameSessionRootState(_canvasTransfrom);

        return controller.Execute(token);
    }
}
