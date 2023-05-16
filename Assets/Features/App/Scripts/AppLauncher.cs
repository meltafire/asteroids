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
        var controller = new AppController();

        controller.Execute(_canvasTransform, _cancelationTokenSource.Token);
    }

    private void OnDestroy()
    {
        _cancelationTokenSource.Cancel();
    }
}
