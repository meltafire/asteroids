using System.Threading;
using UnityEngine;

public interface IUfoSpawnService
{
    Awaitable Execute(CancellationToken token);
}
