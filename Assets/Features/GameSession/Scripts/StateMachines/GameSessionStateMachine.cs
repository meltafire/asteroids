public class GameSessionStateMachine : StateMachine
{
    public GameSessionStateMachine(
        IPlayerToPlayfieldMessaging playerMessaging,
        IStateWithTaskConditionProvider conditionProvider)
        : base()
    {
        _statesQueue.Enqueue(new GameSessionGameState(playerMessaging, conditionProvider));
        _statesQueue.Enqueue(new GameSessionGameOverState());
        _statesQueue.Enqueue(new GameSessionCleanUpState());
    }
}
