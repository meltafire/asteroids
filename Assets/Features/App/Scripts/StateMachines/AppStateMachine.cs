using UnityEngine;

public class AppStateMachine : StateMachine
{
    public AppStateMachine(RectTransform parentTransform) : base()
    {
        _statesQueue.Enqueue(new StartScreenState(parentTransform));
        _statesQueue.Enqueue(new GameSessionState());
    }
}
