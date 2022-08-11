public class IdleStatePlayer : StatePlayer
{
    public override void Exit()
    {
        _player.gameObject.SetActive(true);
    }
    public override void Enter()
    {
        _player.gameObject.SetActive(false);
    }
}
