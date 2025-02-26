using UnityEngine;

public class playerIdleState:PlayerBaseState
{
    public override void EnterState(playerStateManager player)
    {
        player.canGrind=false;
        Debug.Log("Idle");
    }
    public override void UpdateState(playerStateManager player)
    {

        
        player.Fall();
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
