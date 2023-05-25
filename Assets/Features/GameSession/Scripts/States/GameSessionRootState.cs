using System.Threading;
using UnityEngine;

public class GameSessionRootState
{
    private readonly RectTransform _canvasTransfrom;

    public GameSessionRootState(RectTransform canvasTransfrom)
    {
        _canvasTransfrom = canvasTransfrom;
    }

    public async Awaitable Execute(CancellationToken token)
    {
        var collisionService = new CollisionService();

        var borderPlacementService = new BorderPlacementService(Camera.main);

        var playerFacade = new PlayerFacade(borderPlacementService, collisionService);
        var playerMessaging = playerFacade.Execute();

        var asteroidsService = new AsteroidsService(borderPlacementService, borderPlacementService);

        var shotStartData = playerMessaging.GetShotSpawnData();
        var bulletService = new BulletService(shotStartData, borderPlacementService, collisionService);
        var laserService = new LaserService();
        laserService.SpawnLaser(playerMessaging.GetShotSpawnData().ShotStartTransform, collisionService);

        var ufoService = new UfoService(borderPlacementService, playerMessaging);

        while (!token.IsCancellationRequested)
        {
            var gameSessionMessaging = new GameSessionMessaging();

            var stateMachine = new GameSessionStateMachine(
                playerMessaging,
                asteroidsService,
                bulletService,
                laserService,
                ufoService,
                gameSessionMessaging,
                _canvasTransfrom);

            await stateMachine.GoThroughStates(token);
        }
    }
}
