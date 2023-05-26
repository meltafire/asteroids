using System.Threading;
using UnityEngine;

public class GameOverRootState : StateWithTask
{
    private readonly GameOverScoreView _view;
    private readonly ScoresFacade _scoresFacade;

    public GameOverRootState(GameOverScoreView view, ScoresFacade scoresFacade, IStateWithTaskConditionProvider conditionProvider) : base(conditionProvider)
    {
        _view = view;
        _scoresFacade = scoresFacade;
    }

    public override Awaitable Execute(CancellationToken token)
    {
        var model = new GameOverModel(_view);
        var presenter = new GameOverPresenter(_scoresFacade, model);

        presenter.SetScore();

        return base.Execute(token);
    }
}
