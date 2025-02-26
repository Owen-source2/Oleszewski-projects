using UnityEngine;

public class playerWalkState:PlayerBaseState
{

    public override void EnterState(playerStateManager player)
    {
        player.canGrind=true;
        Debug.Log("Walking");
    }
    public override void UpdateState(playerStateManager player)
    {

        player.FindRail(player.grindState);
        player.MovePlayer(player.defaultSpeed,0); 
        player.Fall();
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
