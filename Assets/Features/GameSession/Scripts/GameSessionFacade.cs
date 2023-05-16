using System.Threading;
using UnityEngine;

public class GameSessionFacade
{
    public Awaitable Execute(CancellationToken token)
    {
        var controller = new GameSessionRootState();

        return controller.Execute(token);
    }
}
