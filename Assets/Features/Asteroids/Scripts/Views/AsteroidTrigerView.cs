using UnityEngine;

public class AsteroidTrigerView : MonoBehaviour
{
    [SerializeField]
    private AsteroidView _asteroidView;

    public void HandleBulletCollision()
    {
        _asteroidView.HandleBulletCollision();
    }
}
