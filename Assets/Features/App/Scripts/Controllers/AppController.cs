public class AppController
{
    public void Execute()
    {
        var stateMachine = new StateMachine();

        var state = stateMachine.GetNextState();

        while (state != null)
        {
            state.Execute();

            state = stateMachine.GetNextState();
        }
    }
}
