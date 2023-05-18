using UnityEngine;

public class AsteroidViewFactory
{
    private const string BigAsteroidAdress = "Asteroids/AsteroidBig";
    private const string SmallAsteroidAdress = "Asteroids/AsteroidSmall";

    public AsteroidView Create(AsteroidType asteroidType)
    {
        var adress = asteroidType == AsteroidType.Big ? BigAsteroidAdress : SmallAsteroidAdress;

        var gameObject = Resources.Load<GameObject>(adress);

        var spawnedGameObject = GameObject.Instantiate(gameObject);
        spawnedGameObject.SetActive(false);

        return spawnedGameObject.GetComponent<AsteroidView>();
    }
}
