public class GameSessionStateMachine : StateMachine
{
    public GameSessionStateMachine(IStateWithTaskConditionProvider conditionProvider) : base()
    {
        _statesQueue.Enqueue(new GameSessionGameState(conditionProvider));
        _statesQueue.Enqueue(new GameSessionGameOverState());
        _statesQueue.Enqueue(new GameSessionCleanUpState());
    }
}
