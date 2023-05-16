using System;

public class StartScreenControllerAndPresenterMessaging : IStartScreenPresenterMessaging, IStartScreenFromPresenterMessaging
{
    public event Action OnButtonClick;

    public void InvokeButtonClick()
    {
        OnButtonClick?.Invoke();
    }
}
