using UnityEngine;

public class UfoFactory
{
    private const string UfoAdress = "Ufo/Ufo";

    public UfoView Create()
    {
        var gameObject = Resources.Load<GameObject>(UfoAdress);

        var spawnedGameObject = GameObject.Instantiate(gameObject);
        spawnedGameObject.SetActive(false);

        return spawnedGameObject.GetComponent<UfoView>();
    }
}
