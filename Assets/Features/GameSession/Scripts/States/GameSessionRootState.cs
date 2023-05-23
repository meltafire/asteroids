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

        var shotStartData = playerMessaging.GetShotSpawnData();
        var bulletService = new BulletService(shotStartData, borderPlacementService);

        while (!token.IsCancellationRequested)
        {
            var gameSessionAndPlayerMessaging = new GameSessionAndPlayerMessaging();

            var stateMachine = new GameSessionStateMachine(playerMessaging, asteroidsService, bulletService, gameSessionAndPlayerMessaging);

            await stateMachine.GoThroughStates(token);
        }
    }
}
