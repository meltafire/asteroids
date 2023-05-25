public class OneButtonWindowPresenter
{
    private readonly OneButtonWindowModel _model;
    private readonly IOneButtonWindowMessaging _messaging;

    public OneButtonWindowPresenter(OneButtonWindowModel model, IOneButtonWindowMessaging messaging)
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
