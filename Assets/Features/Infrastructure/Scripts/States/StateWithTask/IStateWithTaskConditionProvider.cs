using System;

public interface IStateWithTaskConditionProvider
{
    event Action ConditionHappened;
}
