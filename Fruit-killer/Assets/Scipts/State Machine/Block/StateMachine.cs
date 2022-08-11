public class StateMachine
{
    public StateBlock CurrentStateBlock { get; private set; }

    public void Initialize(StateBlock startState)
    {
        CurrentStateBlock = startState;
        CurrentStateBlock.Enter();
    }
    public void ChangeStateBlock(StateBlock newStateBlock)
    {
        CurrentStateBlock.Exit();
        CurrentStateBlock = newStateBlock;
        CurrentStateBlock.Enter();
    }
}
