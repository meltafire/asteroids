using UnityEngine;

public class LaserFacade
{
    public ILaserToPlayfieldMessaging SpawnLaser(Transform parentTransform, ICollisionService collisionService)
    {
        var messaging = new LaserMessaging();

        var viewFactory = new LaserViewFactory();

        var view = viewFactory.Create(parentTransform);
        var model = new LaserViewModel(view);
        var presenter = new LaserViewPresenter(model, messaging, collisionService);

        view.Initialize(presenter);

        return messaging;
    }
}
