public class GameSessionStateMachine : StateMachine
{
    private readonly IGameSessionFromPlayerMessaging _gameSessionFromPlayerMessaging;

    public GameSessionStateMachine(IGameSessionFromPlayerMessaging gameSessionFromPlayerMessaging) : base()
    {
        _gameSessionFromPlayerMessaging = gameSessionFromPlayerMessaging;

        _statesQueue.Enqueue(new GameSessionGameState(_gameSessionFromPlayerMessaging));
        _statesQueue.Enqueue(new GameSessionGameOverState());
        _statesQueue.Enqueue(new GameSessionCleanUpState());
    }
}
