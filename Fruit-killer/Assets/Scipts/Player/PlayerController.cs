using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerCharacter _player;

    private StateMachinePlayer _stateMachinePlayer;
    private IdleStatePlayer _idleStatePlayer;
    private MoveStatePlayer _moveStatePlayer;

    private void Awake()
    {
        _idleStatePlayer = new IdleStatePlayer(_player);
        _moveStatePlayer = new MoveStatePlayer(_player);
        _stateMachinePlayer = new StateMachinePlayer();
        _stateMachinePlayer.Initialize(_idleStatePlayer);
    }
    private void Update()
    {
        InputMouse();
        _stateMachinePlayer.CurrentState.Update();
    }

    private void InputMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _stateMachinePlayer.ChangeStatePlayer(_moveStatePlayer);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _stateMachinePlayer.ChangeStatePlayer(_idleStatePlayer);
        }
    }
}
