using UnityEngine;

public abstract class PlayerBaseState
{
   
   public abstract void EnterState(playerStateManager player);
   public abstract void UpdateState(playerStateManager player); 

}
