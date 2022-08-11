using UnityEngine;

public class MoveStatePlayer : StatePlayer
{
    public MoveStatePlayer(PlayerCharacter player)
    {
        _player = player;
    }

    public override void Exit()
    {
        Debug.Log("Move Exit");
    }
    public override void Enter()
    {
        Debug.Log("Move Enter");
    }
    public override void Update()
    {
        _player.MovePlayer();
    }
}
