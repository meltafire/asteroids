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

        OneButtonWindowView view;
        GameOverScoreView scoreView;
        viewFactory.Create(_parentTransform, out view, out scoreView);

        var model = new OneButtonWindowModel(view);

        var messaging = new GameOverMessaging();

        var presenter = new OneButtonWindowPresenter(model, messaging);
        var rootState = new GameOverRootState(scoreView, scoresFacade, messaging);

        view.Initialize(presenter);

        await rootState.Execute(token);

        await Resources.UnloadUnusedAssets();
    }
}
