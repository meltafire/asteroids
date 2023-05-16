using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class StateMachine
{
    protected readonly Queue<IState> _statesQueue;

    public StateMachine()
    {
        _statesQueue = new Queue<IState>();
    }

    public async Awaitable GoThroughStates(CancellationToken token)
    {
        var state = GetNextState();

        while (state != null && !token.IsCancellationRequested)
        {
            await state.Execute(token);

            state = GetNextState();
        }
    }

    private IState GetNextState()
    {
        if (_statesQueue.Count == 0)
        {
            return null;
        }

        return _statesQueue.Dequeue();
    }
}
