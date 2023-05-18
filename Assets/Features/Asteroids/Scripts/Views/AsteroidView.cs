using UnityEngine;

public class AsteroidView : MonoBehaviour
{
    private AsteroidPresenter _presenter;

    public void Initialize(AsteroidPresenter presenter)
    {
        _presenter = presenter;
    }
}
