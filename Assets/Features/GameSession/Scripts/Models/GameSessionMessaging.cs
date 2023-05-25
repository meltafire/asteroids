using System;

public class GameSessionMessaging : IStateWithTaskConditionProvider
{
    public event Action ConditionHappened;

    public void RequestGameEnd()
    {
        ConditionHappened?.Invoke();
    }
}
