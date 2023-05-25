using System.Threading;
using UnityEngine;

public class GameSessionGameOverState : IState
{
    private readonly RectTransform _rectTransform;

    public GameSessionGameOverState(RectTransform rectTransform)
    {
        _rectTransform = rectTransform;
    }

    public Awaitable Execute(CancellationToken token)
    {
        var facade = new GameOverFacade(_rectTransform);

        return facade.Execute(token);
    }
}
