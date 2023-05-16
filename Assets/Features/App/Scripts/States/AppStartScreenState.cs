using System.Threading;
using UnityEngine;

public class AppStartScreenState : IState
{
    private readonly RectTransform _parentTransform;

    public AppStartScreenState(RectTransform parentTransform)
    {
        _parentTransform = parentTransform;
    }

    public Awaitable Execute(CancellationToken token)
    {
        var facade = new StartScreenFacade(_parentTransform);

        return facade.Execute(token);
    }
}
