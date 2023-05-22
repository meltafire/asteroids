public class GameSessionStateMachine : StateMachine
{
    public GameSessionStateMachine(
        IPlayerToPlayfieldMessaging playerMessaging,
        ISpawnAsteroidsService asteroidsService,
        BulletService bulletService,
        IStateWithTaskConditionProvider conditionProvider)
        : base()
    {
        _statesQueue.Enqueue(new GameSessionGameState(playerMessaging, asteroidsService, bulletService, conditionProvider));
        _statesQueue.Enqueue(new GameSessionGameOverState());
        _statesQueue.Enqueue(new GameSessionCleanUpState());
    }
}
