using System.Collections.Generic;

public class StateMachine
{
    private readonly Queue<IState> _statesQueue;

    public StateMachine()
    {
        _statesQueue = new Queue<IState>();

        _statesQueue.Enqueue(new StartScreenState());
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
