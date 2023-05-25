using System.Threading;
using UnityEngine;

public class AppGameSessionState : IState
{
    private readonly RectTransform _canvasTransfrom;

    public AppGameSessionState(RectTransform canvasTransfrom)
    {
        _canvasTransfrom = canvasTransfrom;
    }

    public Awaitable Execute(CancellationToken token)
    {
        var facade = new GameSessionFacade(_canvasTransfrom);

        return facade.Execute(token);
    }
}
