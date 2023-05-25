using UnityEngine;

public class AsteroidViewModel
{
    //private const float LinearSpeedMaxLimit = 2f;

    private readonly AsteroidView _view;

    private Vector3 _velocity = Vector3.zero;

    public Vector3 Velocity => _velocity;
    public Vector3 Position => _view.Position;

    public AsteroidViewModel(AsteroidView view)
    {
        _view = view;
    }

    public void HandleDestroy()
    {
        _view.HandleDestroy();
    }

    public void HandleShow(Vector3 startPosition, Vector3 velocity)
    {
        _view.SetActive(true);

        _velocity = velocity;

        //var speedX = 0f;
        //var speedY = 0f;

        //while (speedX == 0 && speedY == 0)
        //{
        //    speedX = Random.Range(-LinearSpeedMaxLimit, LinearSpeedMaxLimit);
        //    speedY = Random.Range(-LinearSpeedMaxLimit, LinearSpeedMaxLimit);
        //}

        //_velocity = new Vector3(
        //    speedX,
        //    speedY,
        //    0f
        //    );

        _view.Move(startPosition);
    }

    public void HandleHide()
    {
        _view.SetActive(false);
    }

    public void Move(Vector3 position)
    {
        _view.Move(position);
    }
}
