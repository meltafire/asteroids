public class GameSessionStateMachine : StateMachine
{
    public GameSessionStateMachine() : base()
    {
        _statesQueue.Enqueue(new GameState());
        _statesQueue.Enqueue(new GameOverState());
        _statesQueue.Enqueue(new CleanUpState());
    }
}
