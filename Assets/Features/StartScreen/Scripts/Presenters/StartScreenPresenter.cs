public class StartScreenPresenter
{
    private readonly StartScreenModel _model;
    private readonly IStartScreenPresenterMessaging _messaging;

    public StartScreenPresenter(StartScreenModel model, IStartScreenPresenterMessaging messaging)
    {
        _model = model;
        _messaging = messaging;
    }

    public void OnButtonClicked()
    {
        _model.Destroy();

        _messaging.InvokeButtonClick();
    }
}
