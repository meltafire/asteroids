using System.Threading;
using UnityEngine;

public class GameOverFacade
{
    private readonly RectTransform _parentTransform;

    public GameOverFacade(RectTransform parentTransform)
    {
        _parentTransform = parentTransform;
    }

    public async Awaitable Execute(ScoresFacade scoresFacade, CancellationToken token)
    {
        var viewFactory = new GameOverViewFactory();

        var (view, scoreView) = await viewFactory.Create(_parentTransform);

        var model = new OneButtonWindowModel(view);

        var messaging = new GameOverMessaging();

        var presenter = new OneButtonWindowPresenter(model, messaging);
        var rootState = new GameOverRootState(scoreView, scoresFacade, messaging);

        view.Initialize(presenter);

        await rootState.Execute(token);

        viewFactory.Unload();
    }
}
