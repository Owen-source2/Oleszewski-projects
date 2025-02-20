using UnityEngine;

public class playerWalkState:PlayerBaseState
{
    public override void EnterState(playerStateManager player)
    {
        Debug.Log("Walking");
    }
    public override void UpdateState(playerStateManager player)
    {
        player.MovePlayer(player.defaultSpeed); 
        if(player.movement.magnitude<0.1)
        {
            player.SwitchState(player.idleState);
        }
        else if(player.sneak)
        {
            player.SwitchState(player.sneakState);
        }
    } 
}
