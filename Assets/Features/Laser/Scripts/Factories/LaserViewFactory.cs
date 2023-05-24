using UnityEngine;

public class LaserViewFactory
{
    private const string LaserAdress = "Laser/Laser";

    public LaserView Create(Transform parentTransform)
    {
        var gameObject = Resources.Load<GameObject>(LaserAdress);

        var spawnedGameObject = GameObject.Instantiate(gameObject, parentTransform);
        spawnedGameObject.SetActive(false);

        return spawnedGameObject.GetComponent<LaserView>();
    }
}
