using System.Threading;
using UnityEngine;

public class GameSessionCleanUpState : IState
{
    private readonly IDespawnAsteroidsService _asteroidsService;
    private readonly IUfoDespawnService _ufoDespawnService;
    private readonly IBulletDespawnService _bulletDespawnService;

    public GameSessionCleanUpState(IDespawnAsteroidsService asteroidsService, IUfoDespawnService ufoDespawnService, IBulletDespawnService bulletDespawnService)
    {
        _asteroidsService = asteroidsService;
        _ufoDespawnService = ufoDespawnService;
        _bulletDespawnService = bulletDespawnService;
    }

    public Awaitable Execute(CancellationToken token)
    {
        _asteroidsService.DespawnAll();
        _ufoDespawnService.DespawnAll();
        _bulletDespawnService.DespawnAll();

        return Awaitable.EndOfFrameAsync();
    }
}
