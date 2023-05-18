using UnityEngine.Pool;

public class AsteroidsPool
{
    private readonly LinkedPool<AsteroidMessaging> _pool;
    private readonly AsteroidViewFactory _viewFactory;
    private readonly AsteroidType _asteroidType;

    public AsteroidsPool(
        int maxPoolSize,
        AsteroidViewFactory viewFactory,
        AsteroidType asteroidType)
    {
        _asteroidType = asteroidType;
        _viewFactory = viewFactory;

        _pool = new LinkedPool<AsteroidMessaging>(
        CreatePooledItem,
        null,
        null,
        OnDestroyPoolObject,
        false,
        maxPoolSize);
    }

    public AsteroidMessaging GetMessaging()
    {
        return _pool.Get();
    }

    private AsteroidMessaging CreatePooledItem()
    {
        var messaging = new AsteroidMessaging(_pool);
        var view = _viewFactory.Create(_asteroidType);
        var model = new AsteroidViewModel(view);
        var presenter = new AsteroidPresenter(messaging, model);

        view.Initialize(presenter);

        return messaging;
    }

    private void OnDestroyPoolObject(AsteroidMessaging messaging)
    {
        messaging.RequestDestroy();
    }
}
