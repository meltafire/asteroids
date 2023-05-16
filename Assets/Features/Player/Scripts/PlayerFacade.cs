public class PlayerFacade
{
    public IPlayerToPlayfieldMessaging Execute()
    {
        var messaging = new PlayerMessaging();

        var viewFactory = new PlayerViewFactory();

        var view = viewFactory.Create();
        var model = new PlayerViewModel(view);
        var presenter = new PlayerPresenter(messaging, model);

        view.Initialize(presenter);

        return messaging;
    }
}
