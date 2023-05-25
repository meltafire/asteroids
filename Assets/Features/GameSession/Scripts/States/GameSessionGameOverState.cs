using System.Threading;
using UnityEngine;

public class GameSessionGameOverState : IState
{
    public Awaitable Execute(CancellationToken token)
    {
        Debug.Log("game over");

        return Awaitable.WaitForSecondsAsync(1);
    }
}
