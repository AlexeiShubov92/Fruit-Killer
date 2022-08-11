public class StateMachinePlayer
{
    public StatePlayer CurrentState { get; set; }

    public void Initialize(StatePlayer statePlayer)
    {
        CurrentState = statePlayer;
        CurrentState.Enter();
    }
    public void ChangeStatePlayer(StatePlayer newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
