using System.Threading;
using UnityEngine;

public class GameSessionCleanUpState : IState
{
    public Awaitable Execute(CancellationToken token)
    {
        Debug.Log("clean up");

        throw new System.NotImplementedException();
    }
}
