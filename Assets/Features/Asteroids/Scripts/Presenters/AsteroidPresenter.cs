public class AsteroidPresenter
{
    private readonly AsteroidMessaging _messaging;
    private readonly AsteroidViewModel _model;

    public AsteroidPresenter(AsteroidMessaging messaging, AsteroidViewModel model)
    {
        _messaging = messaging;
        _model = model;
    }
}
