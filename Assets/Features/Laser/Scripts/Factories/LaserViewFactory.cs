using UnityEngine;

public class LaserViewFactory
{
    private const string PlayerAdress = "Laser/Laser";

    public LaserView Create(Transform parentTransform)
    {
        var gameObject = Resources.Load<GameObject>(PlayerAdress);

        var spawnedGameObject = GameObject.Instantiate(gameObject, parentTransform);
        spawnedGameObject.SetActive(false);

        return spawnedGameObject.GetComponent<LaserView>();
    }
}
