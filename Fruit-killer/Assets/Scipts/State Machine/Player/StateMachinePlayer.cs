public class StateMachinePlayer
{
    private StatePlayer _currentState;

    public StateMachinePlayer(StatePlayer player)
    {
        _currentState = player;
    }

    public void Initialize(StatePlayer statePlayer)
    {
        _currentState = statePlayer;
        _currentState.Enter();
    }
    public void ChangeStatePlayer(StatePlayer newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
