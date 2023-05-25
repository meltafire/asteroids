public class PlayerFacade
{
    private readonly ILoopPlacementService _service;
    private readonly ICollisionService _collisionService;

    public PlayerFacade(ILoopPlacementService service, ICollisionService collisionService)
    {
        _service = service;
        _collisionService = collisionService;
    }

    public IPlayerToPlayfieldMessaging Execute()
    {
        var messaging = new PlayerMessaging();

        var viewFactory = new PlayerViewFactory();

        var view = viewFactory.Create();
        var model = new PlayerViewModel(view);
        var presenter = new PlayerPresenter(_collisionService, messaging, _service, model);

        view.Initialize(presenter);

        return messaging;
    }
}
