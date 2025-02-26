using UnityEngine;

public class jumpingOffRail:PlayerBaseState
{
    public override void EnterState(playerStateManager player)
    {
        Debug.Log("Leaving Rail");
    }
    public override void UpdateState(playerStateManager player)
    {
        player.control.SimpleMove(new Vector3(0,2.5f,0));
        RaycastHit hit;
        if(Physics.Raycast(player.transform.position,player.transform.up*-1,out hit,10))
        {
            player.SwitchState(player.idleState);
        }
    } 
}
