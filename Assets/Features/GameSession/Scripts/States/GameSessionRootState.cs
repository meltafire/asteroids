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
        var scoreFacade = new ScoresFacade();
        var collisionService = new CollisionService();

        var borderPlacementService = new BorderPlacementService(Camera.main);

        var playerMessaging = LaunchPlayerFeature(borderPlacementService, collisionService);

        var asteroidsService = new AsteroidsService(scoreFacade, borderPlacementService, borderPlacementService);
        asteroidsService.Initialize();

        var bulletService = LaunchBulletFeature(playerMessaging, borderPlacementService, collisionService);

        var laserService = LaunchLaserFeature(playerMessaging, collisionService);
        laserService.Initialize();

        var ufoService = new UfoService(scoreFacade, borderPlacementService, playerMessaging);

        var uiIndicatorFacade = new UiIndicatorFacade(_indicatorsCanvasTransfrom);
        var positionIndicatorService = new PositionIndicatorService(uiIndicatorFacade, playerMessaging);
        positionIndicatorService.CreateIndicator();
        var rotationIndicatorService = new RotationIndicatorService(uiIndicatorFacade, playerMessaging);
        rotationIndicatorService.CreateIndicator();
        var speedIndicatorService = new SpeedIndicatorService(uiIndicatorFacade, playerMessaging);
        speedIndicatorService.CreateIndicator();
        var laserCountIndicator = new LaserCountIndicator(laserService.LaserServiceExternalMessaging, uiIndicatorFacade, playerMessaging);
        laserCountIndicator.CreateIndicator();
        var laserTimeIndicator = new LaserTimeIndicator(laserService.LaserServiceExternalMessaging, uiIndicatorFacade, playerMessaging);
        laserTimeIndicator.CreateIndicator();

        while (!token.IsCancellationRequested)
        {
            var gameSessionMessaging = new GameSessionMessaging();

            scoreFacade.Reset();

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
