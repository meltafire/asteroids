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
        var view = await viewFactory.Create(_parentTransform);

        var model = new OneButtonWindowModel(view);

        var messaging = new StartScreenMessaging();

        var presenter = new OneButtonWindowPresenter(model, messaging);
        var rootState = new StartScreenRootState(messaging);

        view.Initialize(presenter);

        await rootState.Execute(token);

        viewFactory.Unload();
    }
}
