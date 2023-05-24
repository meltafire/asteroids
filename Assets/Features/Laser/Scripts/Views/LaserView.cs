using UnityEngine;

public class LaserView : MonoBehaviour
{
    private LaserViewPresenter _presenter;

    public void Initialize(LaserViewPresenter presenter)
    {
        _presenter = presenter;

        _presenter.OnViewCreated();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ColliderTrigger(Collider2D col)
    {
        _presenter.OnColliderTrigger(col);
    }
}
