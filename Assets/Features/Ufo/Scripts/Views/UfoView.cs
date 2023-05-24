using UnityEngine;

public class UfoView : MonoBehaviour
{
    [SerializeField]
    private TriggerView _triggerView;

    private UfoViewPresenter _presenter;
    private Transform _transform;

    public Vector3 Position => _transform.position;

    public void Initialize(UfoViewPresenter presenter)
    {
        _presenter = presenter;

        _transform = transform;

        _triggerView.TriggerHappened += OnTriggerHappened;

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
        _triggerView.TriggerHappened -= OnTriggerHappened;
    }

    private void OnTriggerHappened()
    {
        _presenter.OnBulletCollision();
    }
}
