public class PlayerFacade
{
    private readonly ILoopPlacementService _service;

    public PlayerFacade(ILoopPlacementService service)
    {
        _service = service;
    }

    public IPlayerToPlayfieldMessaging Execute()
    {
        var messaging = new PlayerMessaging();

        var viewFactory = new PlayerViewFactory();

        var view = viewFactory.Create();
        var model = new PlayerViewModel(view);
        var presenter = new PlayerPresenter(messaging, _service, model);

        view.Initialize(presenter);

        return messaging;
    }
}
