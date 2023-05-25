using System;

public class GameOverMessaging : IOneButtonWindowMessaging, IStateWithTaskConditionProvider
{
    public event Action ConditionHappened;

    public void InvokeButtonClick()
    {
        ConditionHappened?.Invoke();
    }
}
