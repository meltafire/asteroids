public class GameSessionStateMachine : StateMachine
{
    private readonly IGameSessionFromPlayerMessaging _gameSessionFromPlayerMessaging;

    public GameSessionStateMachine(IGameSessionFromPlayerMessaging gameSessionFromPlayerMessaging) : base()
    {
        _gameSessionFromPlayerMessaging = gameSessionFromPlayerMessaging;

        _statesQueue.Enqueue(new GameState(_gameSessionFromPlayerMessaging));
        _statesQueue.Enqueue(new GameOverState());
        _statesQueue.Enqueue(new CleanUpState());
    }
}
