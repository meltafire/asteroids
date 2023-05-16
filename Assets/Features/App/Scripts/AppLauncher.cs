using System.Threading;
using UnityEngine;

public class AppLauncher : MonoBehaviour
{
    [SerializeField]
    private RectTransform _canvasTransform;

    private CancellationTokenSource _cancelationTokenSource;

    private void Awake()
    {
        _cancelationTokenSource = new CancellationTokenSource();
    }

    private void Start()
    {
        var rootState = new AppRootState(_canvasTransform);

        rootState.Execute(_cancelationTokenSource.Token);
    }

    private void OnDestroy()
    {
        _cancelationTokenSource.Cancel();
    }
}
