using System;

public class StartScreenMessaging : IOneButtonWindowMessaging, IStateWithTaskConditionProvider
{
    public event Action ConditionHappened;

    public void InvokeButtonClick()
    {
        ConditionHappened?.Invoke();
    }
}
