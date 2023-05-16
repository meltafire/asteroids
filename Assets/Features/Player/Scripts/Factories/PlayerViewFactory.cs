using UnityEngine;

public class PlayerViewFactory
{
    private const string PlayerAdress = "Player/Player";

    public PlayerView Create()
    {
        var gameObject = Resources.Load<GameObject>(PlayerAdress);

        var spawnedGameObject = GameObject.Instantiate(gameObject);
        spawnedGameObject.SetActive(false);

        return spawnedGameObject.GetComponent<PlayerView>();
    }
}
