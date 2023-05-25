using UnityEngine;

public class GameSessionStateMachine : StateMachine
{
    public GameSessionStateMachine(
        IPlayerToPlayfieldMessaging playerMessaging,
        ISpawnAsteroidsService asteroidsService,
        BulletService bulletService,
        LaserService laserService,
        UfoService ufoService,
        GameSessionMessaging messaging,
        RectTransform canvasTransfrom)
        : base()
    {
        _statesQueue.Enqueue(new GameSessionGameState(playerMessaging, asteroidsService, bulletService, laserService, ufoService, messaging));
        _statesQueue.Enqueue(new GameSessionGameOverState(canvasTransfrom));
        _statesQueue.Enqueue(new GameSessionCleanUpState());
    }
}
