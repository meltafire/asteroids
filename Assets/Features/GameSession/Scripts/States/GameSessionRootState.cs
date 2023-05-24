using System.Threading;
using UnityEngine;

public class GameSessionRootState
{
    public async Awaitable Execute(CancellationToken token)
    {
        var borderPlacementService = new BorderPlacementService(Camera.main);

        var playerFacade = new PlayerFacade(borderPlacementService);
        var playerMessaging = playerFacade.Execute();

        var asteroidsService = new AsteroidsService(borderPlacementService, borderPlacementService);

        var bulletCollisionService = new BulletCollisionService();
        var shotStartData = playerMessaging.GetShotSpawnData();
        var bulletService = new BulletService(shotStartData, borderPlacementService, bulletCollisionService);
        var laserService = new LaserService();
        laserService.SpawnLaser(playerMessaging.GetShotSpawnData().ShotStartTransform, bulletCollisionService);

        var ufoService = new UfoService(borderPlacementService, playerMessaging);

        while (!token.IsCancellationRequested)
        {
            var gameSessionAndPlayerMessaging = new GameSessionAndPlayerMessaging();

            var stateMachine = new GameSessionStateMachine(playerMessaging, asteroidsService, bulletService, laserService, ufoService, gameSessionAndPlayerMessaging);

            await stateMachine.GoThroughStates(token);
        }
    }
}
