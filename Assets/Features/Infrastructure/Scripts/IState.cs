using System.Threading;
using UnityEngine;

public interface IState
{
    Awaitable Execute(CancellationToken token);
}
