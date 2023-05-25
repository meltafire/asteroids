public class BulletPool : Pool<BulletMessaging>
{
    private readonly BulletFactory _viewFactory;
    private readonly IPlayerShotSpawnDataProvider _shotSpawnDataProvider;
    private readonly ICollisionService _collisionService;
    private readonly IOutOfScreenCheck _outOfScreenCheck;

    public BulletPool(
        int maxItemCount,
        BulletFactory viewFactory,
        IPlayerShotSpawnDataProvider shotSpawnDataProvider,
        ICollisionService collisionService,
        IOutOfScreenCheck outOfScreenCheck) : base(maxItemCount)
    {
        _viewFactory = viewFactory;
        _shotSpawnDataProvider = shotSpawnDataProvider;
        _collisionService = collisionService;
        _outOfScreenCheck = outOfScreenCheck;
    }

    public override BulletMessaging CreateItem()
    {
        var messaging = new BulletMessaging(this);
        var view = _viewFactory.Create();
        var model = new BulletViewModel(view);
        var presenter = new BulletViewPresenter(messaging, model, _shotSpawnDataProvider, _collisionService, _outOfScreenCheck);

        view.Initialize(presenter);

        return messaging;
    }

    public override void HandleItemDestroy(BulletMessaging item)
    {
        item.RequestDestroy();
    }

    public override void HandleItemGet(BulletMessaging item)
    {
        item.Show();
    }

    public override void HandleItemRelease(BulletMessaging item)
    {
        item.Hide();
    }
}
