using UnityEngine;

public class BulletPool : Pool<BulletMessaging>
{
    private readonly BulletFactory _viewFactory;
    private readonly IPlayerShotSpawnDataProvider _shotSpawnDataProvider;

    public BulletPool(int maxItemCount, BulletFactory viewFactory, IPlayerShotSpawnDataProvider shotSpawnDataProvider) : base(maxItemCount)
    {
        _viewFactory = viewFactory;
        _shotSpawnDataProvider = shotSpawnDataProvider;
    }

    public override BulletMessaging CreateItem()
    {
        var messaging = new BulletMessaging(this);
        var view = _viewFactory.Create();
        var model = new BulletViewModel(view);
        var presenter = new BulletViewPresenter(messaging, model, _shotSpawnDataProvider);

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
