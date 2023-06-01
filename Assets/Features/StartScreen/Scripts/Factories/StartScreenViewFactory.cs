using UnityEngine;

public class StartScreenViewFactory : AssetLoader
{
    private const string StartScreenAdress = "StartScreen";

    public async Awaitable<OneButtonWindowView> Create(RectTransform parrentTransform)
    {
        var go = await Load(StartScreenAdress, parrentTransform);

        return go.GetComponent<OneButtonWindowView>();
    }
}
