using System.Threading;
using UnityEngine;

public class GameSessionRootState
{
    public async Awaitable Execute(CancellationToken token)
    {
        var loopPlacementService = new LoopPlacementService(Camera.main);

        var playerFacade = new PlayerFacade(loopPlacementService);
        var playerMessaging = playerFacade.Execute();

        var asteroidsService = new AsteroidsService(loopPlacementService, loopPlacementService);

        var shotStartData = playerMessaging.GetShotSpawnData();
        var bulletService = new BulletService(shotStartData);

        while (!token.IsCancellationRequested)
        {
            var gameSessionAndPlayerMessaging = new GameSessionAndPlayerMessaging();

            var stateMachine = new GameSessionStateMachine(playerMessaging, asteroidsService, bulletService, gameSessionAndPlayerMessaging);

            await stateMachine.GoThroughStates(token);
        }
    }
}
