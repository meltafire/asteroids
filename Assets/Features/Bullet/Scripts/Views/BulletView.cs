using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletViewPresenter _presenter;
    private Transform _transform;

    public Vector3 Position => _transform.position;

    private void Update()
    {
        _presenter.OnUpdate();
    }

    public void Initialize(BulletViewPresenter presenter)
    {
        _presenter = presenter;
        _transform = transform;

        _presenter.OnViewCreated();
    }
    
    public void Move(Vector3 position)
    {
        _transform.position = position;
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void HandleDestroy()
    {
        Destroy(gameObject);
    }
}
