using UnityEngine;
using UnityEngine.InputSystem;

public class playerStateManager : MonoBehaviour
{
    CharacterController control;
    PlayerBaseState currentState;
    public playerIdleState idleState = new playerIdleState();
    public playerWalkState walkState = new playerWalkState();
    public playerSneakState sneakState=new playerSneakState();
    public float defaultSpeed = 10;
    [HideInInspector]
    public Vector2 movement;
    [HideInInspector]
    public bool sneak=false;
    Vector3 realMove;
    void Start()
    {
        SwitchState(idleState); 
        control=GetComponent<CharacterController>();
    }

    void Update()
    {
        currentState.UpdateState(this);
    }
    //Movement
    public void MovePlayer(float speed)
    {
        float moveX=movement.x;
        float moveZ=movement.y;
        realMove=new Vector3(moveX,0,moveZ);
        control.Move(realMove*Time.deltaTime*speed);
    }

    //Input
    void OnMove(InputValue moveVal)
    {
        movement=moveVal.Get<Vector2>();

    }
    void OnSprint()
    {
        if(!sneak)
        {
            sneak=true;
        }
        else
        {
            sneak=false;
        }
    }
    
    public void SwitchState(PlayerBaseState newState)
    {
        currentState=newState;
        currentState.EnterState(this);
    }
}
