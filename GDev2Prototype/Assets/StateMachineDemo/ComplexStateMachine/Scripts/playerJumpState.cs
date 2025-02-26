using UnityEngine;

public class playerJumpState:PlayerBaseState
{
    float timeJumping;

    public override void EnterState(playerStateManager player)
    {
        timeJumping=0;
        player.canGrind=false;
        
    }
    public override void UpdateState(playerStateManager player)
    {
        timeJumping+=Time.deltaTime;

        player.MovePlayer(player.defaultSpeed,Jump(player,timeJumping)); 
        if(player.control.velocity.y<=0.1&&player.control.velocity.y>=-0.1&&timeJumping>=0.5)
        {
            player.SwitchState(player.idleState);
        }
    }
    float Jump(playerStateManager player, float timeJumping)
    {


        if(timeJumping<=player.maxAirtime)
        {
            Debug.Log("Jumping");
            return player.fallSpeed*-1;
        }
        else
        {
            Debug.Log("Falling");
            return player.fallSpeed;
        }
    }
}
