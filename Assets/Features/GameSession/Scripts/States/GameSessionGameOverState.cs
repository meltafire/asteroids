using System.Threading;
using UnityEngine;

public class GameSessionGameOverState : IState
{
    private readonly RectTransform _rectTransform;
    private readonly ScoresFacade _scoresFacade;

    public GameSessionGameOverState(ScoresFacade scoresFacade, RectTransform rectTransform)
    {
        _rectTransform = rectTransform;
        _scoresFacade = scoresFacade;
    }

    public Awaitable Execute(CancellationToken token)
    {
        var facade = new GameOverFacade(_rectTransform);

        return facade.Execute(_scoresFacade, token);
    }
}
