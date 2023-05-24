using UnityEngine;

public class AsteroidView : MonoBehaviour
{
    private AsteroidPresenter _presenter;
    private Transform _transform;

    public Vector3 Position => _transform.position;

    public void Initialize(AsteroidPresenter presenter)
    {
        _presenter = presenter;

        _transform = gameObject.transform;

        _presenter.OnViewCreated();
    }

    public void HandleBulletCollision()
    {
        _presenter.OnBulletCollision();
    }

    public void HandleDestroy()
    {
        Destroy(gameObject);
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void Move(Vector3 position)
    {
        _transform.position = position;
    }

    private void Update()
    {
        _presenter.OnUpdate(_transform.position);
    }
}
