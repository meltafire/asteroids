using System;
using UnityEngine;

public class AsteroidView : MonoBehaviour
{
    [SerializeField]
    private CollisionTriggerView _triggerView;

    private AsteroidPresenter _presenter;
    private Transform _transform;

    public Vector3 Position => _transform.position;

    public void Initialize(AsteroidPresenter presenter)
    {
        _presenter = presenter;

        _transform = gameObject.transform;

        _triggerView.TriggerHappened += OnTriggerHappened;

        _presenter.OnViewCreated();
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

    private void OnDestroy()
    {
        _triggerView.TriggerHappened -= OnTriggerHappened;
    }

    private void OnTriggerHappened()
    {
        _presenter.OnBulletCollision();
    }
}
