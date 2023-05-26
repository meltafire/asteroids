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

        var asteroidsService = SetupAsteroidService(scoreFacade, borderPlacementService);

        var bulletService = LaunchBulletFeature(playerMessaging, borderPlacementService, collisionService);

        var laserService = SetupLaserService(playerMessaging, collisionService);

        var ufoService = new UfoService(scoreFacade, borderPlacementService, playerMessaging);

        SetupIndicators(playerMessaging, laserService.LaserServiceExternalMessaging);

        while (!token.IsCancellationRequested)
        {
            var gameSessionMessaging = new GameSessionMessaging();

            scoreFacade.Reset();

            var stateMachine = new GameSessionStateMachine(
                scoreFacade,
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

    private AsteroidsService SetupAsteroidService(ScoresFacade scoreFacade, BorderPlacementService borderPlacementService)
    {
        var asteroidsService = new AsteroidsService(scoreFacade, borderPlacementService, borderPlacementService);
        asteroidsService.Initialize();

        return asteroidsService;
    }

    private LaserService SetupLaserService(IPlayerToPlayfieldMessaging playerMessaging, CollisionService collisionService)
    {
        var laserService = LaunchLaserFeature(playerMessaging, collisionService);
        laserService.Initialize();

        return laserService;
    }

    private void SetupIndicators(IPlayerToPlayfieldMessaging playerMessaging, ILaserServiceExternalMessaging laserService)
    {
        var uiIndicatorFacade = new UiIndicatorFacade(_indicatorsCanvasTransfrom);
        var positionIndicatorService = new PositionIndicatorService(uiIndicatorFacade, playerMessaging);
        positionIndicatorService.CreateIndicator();
        var rotationIndicatorService = new RotationIndicatorService(uiIndicatorFacade, playerMessaging);
        rotationIndicatorService.CreateIndicator();
        var speedIndicatorService = new SpeedIndicatorService(uiIndicatorFacade, playerMessaging);
        speedIndicatorService.CreateIndicator();
        var laserCountIndicator = new LaserCountIndicator(laserService, uiIndicatorFacade, playerMessaging);
        laserCountIndicator.CreateIndicator();
        var laserTimeIndicator = new LaserTimeIndicator(laserService, uiIndicatorFacade, playerMessaging);
        laserTimeIndicator.CreateIndicator();
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
