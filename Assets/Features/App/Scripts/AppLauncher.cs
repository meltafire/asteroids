using UnityEngine;

public class AppLauncher : MonoBehaviour
{
    [SerializeField]
    private RectTransform _canvasTransform;
    [SerializeField]
    private RectTransform _indicatorsCanvasTransfrom;

    private Awaitable Start()
    {
        var rootState = new AppRootState();

        return rootState.Execute(_canvasTransform, _indicatorsCanvasTransfrom, destroyCancellationToken);
    }
}
