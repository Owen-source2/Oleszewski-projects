using UnityEngine;

public class playerSneakState:PlayerBaseState
{
    public override void EnterState(playerStateManager player)
    {
        Debug.Log("Sneaking");
    }
    public override void UpdateState(playerStateManager player)
    {
        player.MovePlayer(player.defaultSpeed/2); 
        if(player.movement.magnitude<0.1)
        {
            player.SwitchState(player.idleState);
        }
        else if(player.sneak==false)
        {
            player.SwitchState(player.walkState);
        }
    }
    
}
