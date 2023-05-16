using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private readonly Queue<IState> _statesQueue;

    public StateMachine(RectTransform parentTransform)
    {
        _statesQueue = new Queue<IState>();

        _statesQueue.Enqueue(new StartScreenState(parentTransform));
        _statesQueue.Enqueue(new GameSessionState());
    }

    public IState GetNextState()
    {
        if (_statesQueue.Count == 0)
        {
            return null;
        }

        return _statesQueue.Dequeue();
    }
}
