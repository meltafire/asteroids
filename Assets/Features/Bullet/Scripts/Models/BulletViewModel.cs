using UnityEngine;

public class BulletViewModel
{
    private const float Speed = 5f;

    private readonly BulletView _view;

    private Vector3 _velocity;

    public Vector3 Velocity => _velocity;

    public BulletViewModel(BulletView view)
    {
        _view = view;
    }

    public void HandleShow(IPlayerShotSpawnDataProvider shotSpawnDataProvider)
    {
        _velocity = shotSpawnDataProvider.Direction * Speed;

        _view.Move(shotSpawnDataProvider.ShotStartPosition);

        _view.SetActive(true);
    }

    public void HandleHide()
    {
        _view.SetActive(false);
    }

    public void Move(Vector3 position)
    {
        _view.Move(position);
    }

    public void HandleDestroy()
    {
        _view.HandleDestroy();
    }

    public void Move()
    {
        _view.Move(_view.Position + _velocity * Time.deltaTime);
    }
}
