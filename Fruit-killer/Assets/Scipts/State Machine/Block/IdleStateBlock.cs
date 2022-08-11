using UnityEngine;

public class IdleStateBlock : StateBlock
{
    public IdleStateBlock(Block block)
    {
        _block = block;
    }

    public override void Enter()
    {
        Debug.Log("Idle enter");
        //_block.SetStartOptions();
        _block.gameObject.SetActive(false);
    }

    public override void Exit()
    {
        Debug.Log("Idle exit");
        _block.gameObject.SetActive(true);
    }
}
