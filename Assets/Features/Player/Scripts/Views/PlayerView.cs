using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerPresenter _presenter;
    private Transform _transform;

    public void Initialize(PlayerPresenter presenter)
    {
        _presenter = presenter;
        _transform = transform;

        _presenter.OnViewCreated();
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
    }
}
