using System.Threading;
using UnityEngine;

public class StartScreenState : IState
{
    private readonly RectTransform _parentTransform;

    public StartScreenState(RectTransform parentTransform)
    {
        _parentTransform = parentTransform;
    }

    public Awaitable Execute(CancellationToken token)
    {
        var facade = new StartScreenFacade(_parentTransform);

        return facade.Execute(token);
    }
}
