using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class playerStateManager : MonoBehaviour
{
    public CharacterController control;
    public PlayerBaseState currentState;
    public playerIdleState idleState = new playerIdleState();
    public playerWalkState walkState = new playerWalkState();
    public playerSneakState sneakState=new playerSneakState();
    public playerGrindState grindState=new playerGrindState();
    public jumpingOffRail jumpOff=new jumpingOffRail();
    public playerJumpState jumpState=new playerJumpState();
    public float defaultSpeed = 20;
    [SerializeField] GameObject camera;
    [HideInInspector]
    public Vector2 movement;
    [HideInInspector]
    public bool sneak=false;
    Vector3 realMove;
    public float fallSpeed = -9.81f;
    [HideInInspector]public bool onRail = false;
    public railScript currentRailScript;
    public float grindSpeed;
    public bool canGrind=true;
    public float maxAirtime=3.0f;
    
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
    public void MovePlayer(float speed, float fallSpeed)
    {
        float moveX=movement.x;
        float moveZ=movement.y;
        realMove=new Vector3(moveX,fallSpeed,moveZ);
        Vector3 moveForLook=new Vector3(realMove.x,0,realMove.z);
        Vector3 look=Vector3.RotateTowards(transform.forward,moveForLook,0.5f,0.5f);
        transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(look),0.2f);
        control.Move(transform.rotation*(realMove*Time.deltaTime*speed));
    }

    //Input
    void OnMove(InputValue moveVal)
    {
        movement=moveVal.Get<Vector2>();

    }
    public void Fall()
    {
        control.Move(new Vector3(0,fallSpeed,0)*Time.deltaTime);
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
    void OnJump()
    {
        if(currentState!=jumpState)
        {
            SwitchState(jumpState);
        }
    }
    public void FindRail(PlayerBaseState newState)
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position,transform.forward*10,Color green);
        if(Physics.Raycast(transform.position,transform.up*-1,out hit,10))
        {
            if(hit.transform!=null)
            {
                //Debug.Log(canGrind);
                if(hit.transform.gameObject.GetComponent<SplineExtrude>()&&canGrind)
                {
                    currentRailScript = hit.transform.gameObject.GetComponent<railScript>();
                    onRail=true;
                    currentState=newState;
                    SwitchState(grindState);
                }
                else
                {
                    onRail=false;
                }
            }
        }
    }
    
    public void SwitchState(PlayerBaseState newState)
    {
        currentState=newState;
        currentState.EnterState(this);
    }
}
