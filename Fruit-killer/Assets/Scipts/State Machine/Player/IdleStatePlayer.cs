using UnityEngine;
public class IdleStatePlayer : StatePlayer
{
    public IdleStatePlayer(PlayerCharacter player)
    {
        _player = player;
    }

    public override void Exit()
    {
        Debug.Log("Idle Exit");

        _player.PlayerIsActive = true;
    }
    public override void Enter()
    {
        Debug.Log("Idle Enter");

        _player.PlayerIsActive = false;
    }
    public override void Update()
    {

    }
}
