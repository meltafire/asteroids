using System;

public class StartScreenControllerAndPresenterMessaging : IStartScreenPresenterMessaging, IStateWithTaskConditionProvider
{
    public event Action ConditionHappened;

    public void InvokeButtonClick()
    {
        ConditionHappened?.Invoke();
    }
}
