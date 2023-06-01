using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class AssetLoader
{
    private static string AssetError = "Asset load error {0}";

    private GameObject _cachedObject;

    protected async Awaitable<GameObject> Load(string assetId)
    {
        var handle = Addressables.InstantiateAsync(assetId);
        return await handle.Task;
    }

    protected async Awaitable<GameObject> Load(string assetId, Transform parent)
    {
        var handle = Addressables.InstantiateAsync(assetId, parent);
        return await handle.Task;
    }

    public void Unload()
    {
        if (_cachedObject == null)
        {
            return;
        }

        Addressables.ReleaseInstance(_cachedObject);

        _cachedObject = null;
    }
}
