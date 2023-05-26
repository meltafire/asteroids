using UnityEngine;

public class GameSessionStateMachine : StateMachine
{
    public GameSessionStateMachine(
        ScoresFacade scoresFacade,
        IPlayerToPlayfieldMessaging playerMessaging,
        ISpawnAsteroidsService asteroidsService,
        IDespawnAsteroidsService despawnAsteroidsService,
        IBulletService bulletService,
        IBulletDespawnService bulletDespawnService,
        LaserService laserService,
        IUfoSpawnService ufoService,
        IUfoDespawnService ufoDespawnService,
        GameSessionMessaging messaging,
        RectTransform canvasTransfrom)
        : base()
    {
        _statesQueue.Enqueue(new GameSessionGameState(playerMessaging, asteroidsService, bulletService, laserService, ufoService, messaging));
        _statesQueue.Enqueue(new GameSessionGameOverState(scoresFacade, canvasTransfrom));
        _statesQueue.Enqueue(new GameSessionCleanUpState(despawnAsteroidsService, ufoDespawnService, bulletDespawnService));
    }
}
