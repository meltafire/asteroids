public class GameSessionStateMachine : StateMachine
{
    public GameSessionStateMachine(
        IPlayerToPlayfieldMessaging playerMessaging,
        ISpawnAsteroidsService asteroidsService,
        BulletService bulletService,
        LaserService laserService,
        UfoService ufoService,
        GameSessionMessaging messaging)
        : base()
    {
        _statesQueue.Enqueue(new GameSessionGameState(playerMessaging, asteroidsService, bulletService, laserService, ufoService, messaging));
        _statesQueue.Enqueue(new GameSessionGameOverState());
        _statesQueue.Enqueue(new GameSessionCleanUpState());
    }
}
