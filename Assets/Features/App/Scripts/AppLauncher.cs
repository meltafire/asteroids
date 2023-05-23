using UnityEngine;

public class AppLauncher : MonoBehaviour
{
    [SerializeField]
    private RectTransform _canvasTransform;

    private Awaitable Start()
    {
        var rootState = new AppRootState(_canvasTransform);

        return rootState.Execute(destroyCancellationToken);
    }
}
