using UnityEngine;

public class UfoView : MonoBehaviour
{
    [SerializeField]
    private CollisionTriggerView _collistionTriggerView;

    private UfoViewPresenter _presenter;
    private Transform _transform;

    public Vector3 Position => _transform.position;

    public void Initialize(UfoViewPresenter presenter)
    {
        _presenter = presenter;

        _transform = transform;

        _collistionTriggerView.TriggerHappened += OnTriggerHappened;

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

    private void Update()
    {
        _presenter.OnUpdate();
    }

    private void OnDestroy()
    {
        _collistionTriggerView.TriggerHappened -= OnTriggerHappened;
    }

    private void OnTriggerHappened()
    {
        _presenter.OnBulletCollision();
    }
}
