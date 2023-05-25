using System.Threading;
using UnityEngine;

public class GameOverFacade
{
    private readonly RectTransform _parentTransform;

    public GameOverFacade(RectTransform parentTransform)
    {
        _parentTransform = parentTransform;
    }

    public async Awaitable Execute(CancellationToken token)
    {
        var viewFactory = new GameOverViewFactory();
        var view = viewFactory.Create(_parentTransform);

        var model = new OneButtonWindowModel(view);

        var messaging = new GameOverMessaging();

        var presenter = new OneButtonWindowPresenter(model, messaging);
        var rootState = new GameOverRootState(messaging);

        view.Initialize(presenter);

        await rootState.Execute(token);

        await Resources.UnloadUnusedAssets();
    }
}
