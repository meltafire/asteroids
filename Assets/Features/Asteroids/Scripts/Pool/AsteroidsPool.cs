public class AsteroidsPool : Pool<AsteroidMessaging>
{
    private readonly AsteroidViewFactory _viewFactory;
    private readonly AsteroidType _asteroidType;
    private readonly ILoopPlacementService _loopPlacementService;
    private readonly IOutOfScreenPlacementService _outOfScreenPlacementService;

    public AsteroidsPool(
        int maxPoolSize,
        AsteroidViewFactory viewFactory,
        AsteroidType asteroidType,
        ILoopPlacementService loopPlacementService,
        IOutOfScreenPlacementService outOfScreenPlacementService)
        : base (maxPoolSize)
    {
        _asteroidType = asteroidType;
        _viewFactory = viewFactory;
        _loopPlacementService = loopPlacementService;
        _outOfScreenPlacementService = outOfScreenPlacementService;
    }

    public override AsteroidMessaging CreateItem()
    {
        var messaging = new AsteroidMessaging(this);
        var view = _viewFactory.Create(_asteroidType);
        var model = new AsteroidViewModel(view);
        var presenter = new AsteroidPresenter(messaging, model, _loopPlacementService, _outOfScreenPlacementService);

        view.Initialize(presenter);

        return messaging;
    }

    public override void HandleItemGet(AsteroidMessaging item)
    {
        item.Show();
    }

    public override void HandleItemRelease(AsteroidMessaging item)
    {
        item.Hide();
    }

    public override void HandleItemDestroy(AsteroidMessaging item)
    {
        item.RequestDestroy();
    }
}
