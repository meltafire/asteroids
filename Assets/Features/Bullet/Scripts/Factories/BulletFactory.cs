using UnityEngine;

public class BulletFactory
{
    private const string BigAsteroidAdress = "Bullet/Bullet";

    public BulletView Create()
    {
        var gameObject = Resources.Load<GameObject>(BigAsteroidAdress);

        var spawnedGameObject = GameObject.Instantiate(gameObject);
        spawnedGameObject.SetActive(false);

        return spawnedGameObject.GetComponent<BulletView>();
    }
}
