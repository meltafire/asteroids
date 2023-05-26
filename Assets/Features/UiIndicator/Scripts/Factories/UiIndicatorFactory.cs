using UnityEngine;

public class UiIndicatorFactory
{
    private const string UiIndicatorAdress = "UiIndicator";

    public UiIndicatorView Create(RectTransform parentTransform)
    {
        var gameObject = Resources.Load<GameObject>(UiIndicatorAdress);

        var spawnedGameObject = GameObject.Instantiate(gameObject, parentTransform);
        spawnedGameObject.SetActive(false);

        return spawnedGameObject.GetComponent<UiIndicatorView>();
    }
}
