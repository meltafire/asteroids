using System;

public class UiIndicatorMessaging : IUiIndicatorMessaging, IUiIndicatorExternalMessaging
{
    public event Action<string> Show;
    public event Action Hide;
    public event Action<string> UpdateText;

    void IUiIndicatorExternalMessaging.Hide()
    {
        Hide?.Invoke();
    }

    void IUiIndicatorExternalMessaging.Show(string text)
    {
        Show?.Invoke(text);
    }

    void IUiIndicatorExternalMessaging.UpdateText(string text)
    {
        UpdateText?.Invoke(text);
    }
}
