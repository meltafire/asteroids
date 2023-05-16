using System.Threading;
using UnityEngine;

public class GameSessionState : IState
{
    public Awaitable Execute(CancellationToken token)
    {
        var facade = new GameSessionFacade();

        return facade.Execute(token);
    }
}
