using System.Threading;
using UnityEngine;

public class AppGameSessionState : IState
{
    public Awaitable Execute(CancellationToken token)
    {
        var facade = new GameSessionFacade();

        return facade.Execute(token);
    }
}
