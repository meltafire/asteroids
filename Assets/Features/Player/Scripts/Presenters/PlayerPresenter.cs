using System;

public class PlayerPresenter : IDisposable
{
    private readonly IPlayerMessaging _playerMessaging;
    private readonly PlayerViewModel _model;

    public PlayerPresenter(IPlayerMessaging playerMessaging, PlayerViewModel model)
    {
        _playerMessaging = playerMessaging;
        _model = model;
    }

    public void Dispose()
    {
        _playerMessaging.SpawnRequest -= OnSpawnRequested;
    }

    public void OnViewCreated()
    {
        _playerMessaging.SpawnRequest += OnSpawnRequested;
    }

    private void OnSpawnRequested()
    {
        _model.SpawnPlayer();
    }
}
