using System.Threading;
using UnityEngine;

public class GameSessionFacade
{
    public Awaitable Execute(CancellationToken token)
    {
        var controller = new GameSessionController();

        return controller.Execute(token);
    }
}
