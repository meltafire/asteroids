using UnityEngine;

public class AppStateMachine : StateMachine
{
    public AppStateMachine(RectTransform parentTransform, RectTransform indicatorsCanvasTransfrom) : base()
    {
        _statesQueue.Enqueue(new AppStartScreenState(parentTransform));
        _statesQueue.Enqueue(new AppGameSessionState(parentTransform, indicatorsCanvasTransfrom));
    }
}
