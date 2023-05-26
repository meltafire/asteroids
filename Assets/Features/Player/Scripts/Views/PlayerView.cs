using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Transform _shotStartTransform;

    private PlayerPresenter _presenter;
    private Transform _transform;

    public Vector3 ForwardDirection => _transform.up;
    public Transform ShotStartTransform => _shotStartTransform;
    public Vector3 Position => _transform.position;

    private void Update()
    {
        _presenter.OnUpdate();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _presenter.OnColliderTrigger(col);
    }

    public void Initialize(PlayerPresenter presenter)
    {
        _presenter = presenter;
        _transform = transform;

        _presenter.OnViewCreated();
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void Rotate(Vector3 rotation)
    {
        _transform.Rotate(rotation);
    }

    public void Move(Vector3 position)
    {
        _transform.position = position;
    }
}
