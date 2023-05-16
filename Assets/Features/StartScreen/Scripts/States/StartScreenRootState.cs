using System.Threading;
using UnityEngine;

public class StartScreenRootState
{
    private readonly IStartScreenFromPresenterMessaging _messaging;

    private AwaitableCompletionSource _completionSource;

    public StartScreenRootState(IStartScreenFromPresenterMessaging messaging)
    {
        _messaging = messaging;
    }

    public async Awaitable Execute(CancellationToken token)
    {
        _completionSource = new AwaitableCompletionSource();
        var tokenRegistration = token.Register(CancelAwaitingOfButtonClick);

        _messaging.OnButtonClick += OnButtonClicked;

        await _completionSource.Awaitable;

        _messaging.OnButtonClick -= OnButtonClicked;
        tokenRegistration.Dispose();
    }

    private void CancelAwaitingOfButtonClick()
    {
        _completionSource.TrySetCanceled();
    }

    private void OnButtonClicked()
    {
        _completionSource.TrySetResult();
    }
}
