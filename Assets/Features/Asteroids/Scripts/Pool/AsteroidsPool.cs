public class AsteroidsPool : Pool<AsteroidMessaging>
{
    private readonly AsteroidViewFactory _viewFactory;
    private readonly AsteroidType _asteroidType;
    private readonly ILoopPlacementService _loopPlacementService;

    public AsteroidsPool(
        int maxPoolSize,
        AsteroidViewFactory viewFactory,
        AsteroidType asteroidType,
        ILoopPlacementService loopPlacementService)
        : base (maxPoolSize)
    {
        _asteroidType = asteroidType;
        _viewFactory = viewFactory;
        _loopPlacementService = loopPlacementService;
    }

    public override AsteroidMessaging CreateItem()
    {
        var messaging = new AsteroidMessaging(this, _asteroidType);
        var view = _viewFactory.Create(_asteroidType);
        var model = new AsteroidViewModel(view);
        var presenter = new AsteroidPresenter(messaging, model, _loopPlacementService);

        view.Initialize(presenter);

        return messaging;
    }

    public override void HandleItemRelease(AsteroidMessaging item)
    {
        item.Hide();
    }

    public override void HandleItemDestroy(AsteroidMessaging item)
    {
        item.RequestDestroy();
    }

    public override void HandleItemGet(AsteroidMessaging item)
    {
    }
}
