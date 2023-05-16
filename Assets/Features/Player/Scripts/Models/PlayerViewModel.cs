public class PlayerViewModel
{
    private readonly PlayerView _playerView;

    public PlayerViewModel(PlayerView playerView)
    {
        _playerView = playerView;
    }

    public void SpawnPlayer()
    {
        _playerView.Spawn();
    }
}
