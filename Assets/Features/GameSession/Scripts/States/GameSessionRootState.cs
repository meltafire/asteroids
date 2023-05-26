using System.Threading;
using UnityEngine;

public class GameSessionRootState
{
    private readonly RectTransform _canvasTransfrom;
    private readonly RectTransform _indicatorsCanvasTransfrom;

    public GameSessionRootState(RectTransform canvasTransfrom, RectTransform indicatorsCanvasTransfrom)
    {
        _canvasTransfrom = canvasTransfrom;
        _indicatorsCanvasTransfrom = indicatorsCanvasTransfrom;
    }

    public async Awaitable Execute(CancellationToken token)
    {
        var collisionService = new CollisionService();

        var borderPlacementService = new BorderPlacementService(Camera.main);

        var playerMessaging = LaunchPlayerFeature(borderPlacementService, collisionService);
        var asteroidsService = new AsteroidsService(borderPlacementService, borderPlacementService);
        var bulletService = LaunchBulletFeature(playerMessaging, borderPlacementService, collisionService);
        var laserService = LaunchLaserFeature(playerMessaging, collisionService);
        var ufoService = new UfoService(borderPlacementService, playerMessaging);

        var uiIndicatorFacade = new UiIndicatorFacade(_indicatorsCanvasTransfrom);
        var positionIndicatorService = new PositionIndicatorService(uiIndicatorFacade, playerMessaging);
        positionIndicatorService.CreateIndicator();
        var rotationIndicatorService = new RotationIndicatorService(uiIndicatorFacade, playerMessaging);
        rotationIndicatorService.CreateIndicator();

        while (!token.IsCancellationRequested)
        {
            var gameSessionMessaging = new GameSessionMessaging();

            var stateMachine = new GameSessionStateMachine(
                playerMessaging,
                asteroidsService,
                asteroidsService,
                bulletService,
                bulletService,
                laserService,
                ufoService,
                ufoService,
                gameSessionMessaging,
                _canvasTransfrom);

            await stateMachine.GoThroughStates(token);
        }
    }

    private IPlayerToPlayfieldMessaging LaunchPlayerFeature(BorderPlacementService borderPlacementService, CollisionService collisionService)
    {
        var playerFacade = new PlayerFacade(borderPlacementService, collisionService);

        return playerFacade.Execute();
    }

    private BulletService LaunchBulletFeature(IPlayerToPlayfieldMessaging playerMessaging, BorderPlacementService borderPlacementService, CollisionService collisionService)
    {
        var shotStartData = playerMessaging.GetShotSpawnData();

        return new BulletService(shotStartData, borderPlacementService, collisionService);
    }

    private LaserService LaunchLaserFeature(IPlayerToPlayfieldMessaging playerMessaging, CollisionService collisionService)
    {
        var laserService = new LaserService();
        laserService.SpawnLaser(playerMessaging.GetShotSpawnData().ShotStartTransform, collisionService);

        return laserService;
    }
}
