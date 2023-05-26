using System;

public class UiIndicatorPresenter : IDisposable
{
    private readonly UiIndicatorModel _model;
    private readonly IUiIndicatorMessaging _messaging;

    public UiIndicatorPresenter(UiIndicatorModel model, IUiIndicatorMessaging messaging)
    {
        _model = model;
        _messaging = messaging;
    }

    public void OnViewCreated()
    {
        _messaging.Show += OnShow;
        _messaging.Hide += OnHide;
        _messaging.UpdateText += OnTextUpdate;
    }

    public void Dispose()
    {
        _messaging.Show -= OnShow;
        _messaging.Hide -= OnHide;
        _messaging.UpdateText -= OnTextUpdate;
    }

    private void OnShow(string text)
    {
        _model.Show();

        OnTextUpdate(text);
    }

    private void OnHide()
    {
        _model.Hide();
    }

    private void OnTextUpdate(string text)
    {
        _model.SetText(text);
    }
}
