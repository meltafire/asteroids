using System.Threading;
using UnityEngine;

public abstract class StateWithTask : IState
{
    private readonly IStateWithTaskConditionProvider _conditionProvider;

    private AwaitableCompletionSource _completionSource;

    protected StateWithTask(IStateWithTaskConditionProvider conditionProvider)
    {
        _conditionProvider = conditionProvider;
    }

    public virtual async Awaitable Execute(CancellationToken token)
    {
        _completionSource = new AwaitableCompletionSource();
        var tokenRegistration = token.Register(CancelAwaitingForCondition);

        _conditionProvider.ConditionHappened += OnConditionHappened;

        if (!token.IsCancellationRequested)
        {
            await _completionSource.Awaitable;
        }

        _conditionProvider.ConditionHappened  -= OnConditionHappened;

        tokenRegistration.Dispose();
    }

    private void CancelAwaitingForCondition()
    {
        _completionSource.TrySetCanceled();
    }

    private void OnConditionHappened()
    {
        _completionSource.TrySetResult();
    }
}
