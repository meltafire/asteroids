using System.Threading;
using UnityEngine;

public class StartScreenFacade
{
    private readonly RectTransform _parentTransform;

    public StartScreenFacade(RectTransform parentTransform)
    {
        _parentTransform = parentTransform;
    }

    public async Awaitable Execute(CancellationToken token)
    {
        var viewFactory = new StartScreenViewFactory();
        var view = viewFactory.Create(_parentTransform);

        var model = new StartScreenModel(view);

        var messaging = new StartScreenControllerAndPresenterMessaging();

        var presenter = new StartScreenPresenter(model, messaging);
        var controller = new StartScreenController(messaging);

        view.Initialize(presenter);

        await controller.Execute(token);

        await Resources.UnloadUnusedAssets();
    }
}
