using UnityEngine;

public class playerIdleState:PlayerBaseState
{
    public override void EnterState(playerStateManager player)
    {
        Debug.Log("Idle");
    }
    public override void UpdateState(playerStateManager player)
    {
        //Do Nothing
        if(player.movement.magnitude>0.1)
        {
            if(player.sneak)
            {
                player.SwitchState(player.sneakState);
            }
            else
            {
                player.SwitchState(player.walkState);
            }
        }
        
    }
}
