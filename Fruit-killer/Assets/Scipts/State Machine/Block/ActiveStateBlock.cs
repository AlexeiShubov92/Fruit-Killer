using UnityEngine;

public class ActiveStateBlock : StateBlock
{
    public ActiveStateBlock(Block block)
    {
        _block = block;
    }
    public override void Enter()
    {
        Debug.Log("Active enter");
    }

    public override void Exit()
    {
        Debug.Log("Active exit");
    }

    public override void Update()
    {
        //_block.Move();
    }
}
