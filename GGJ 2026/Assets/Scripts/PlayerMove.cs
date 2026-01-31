using System.Collections;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public bool onGround;
    public LayerMask groundLayer;
    public GameObject groundCheckL, groundCheckR;
    public Rigidbody2D rb2d;
    public int speed;
    public int topHorizontalSpeed;
    public int jumpForce;
    public int terminalVel;
    public float fallSpeed;
    float groundFriction;
    float gravity;
    public int airSpeed;
    public float coyoteTime;
    public int stompSpeed;
    bool stomping=false;
    public float stompMass;
    float massInit;
    int terminalVelInit;
    public float warpOffsetY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gravity=rb2d.gravityScale;
        groundFriction=rb2d.linearDamping;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D lHit = Physics2D.Linecast(transform.position, groundCheckL.transform.position, groundLayer);
        RaycastHit2D rHit = Physics2D.Linecast(transform.position, groundCheckR.transform.position, groundLayer);
        if (lHit || rHit)
        {
            onGround=true;
        }
        else
        {
            StartCoroutine("LeaveGround");
        }
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(0,jumpForce));
        }
        else if (onGround)
        {
            rb2d.gravityScale=0;
            rb2d.linearDamping=groundFriction;
        }
        else
        {
            rb2d.gravityScale=gravity;
            rb2d.linearDamping=fallSpeed;
            rb2d.linearVelocityY=Mathf.Clamp(rb2d.linearVelocityY,-terminalVel,terminalVel);
        }
        if (stomping)
        {
            if(!onGround)
            {
                Stomp();
            }
            else
            {
                StopStomp();
            }
        }
        //Debug.Log(onGround);
    }
    void FixedUpdate() 
    {
        if(onGround)
        {
            rb2d.AddForce(Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw("Horizontal"),0)*speed,topHorizontalSpeed));
        }
        else
        {
            
            rb2d.AddForce(Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw("Horizontal"),0)*airSpeed,topHorizontalSpeed));
        }
    }
    IEnumerator LeaveGround()
    {
        yield return new WaitForSeconds(coyoteTime);
        onGround=false;
    }
    //Mask abilities
    public void StartDash()
    {
        print("Dash");
    }
    public void StartStomp()
    {
        print("Stomp");
        stomping=true;
        massInit=rb2d.mass;
        terminalVelInit=terminalVel;
    }
    void Stomp()
    {
        //rb2d.mass=stompMass;
        rb2d.AddForceY(-stompSpeed);
        terminalVel=stompSpeed*2;
    }
    void StopStomp()
    {
        //rb2d.mass=massInit;
        terminalVel=terminalVelInit;
        stomping=false;
    }
    public void StartWarp()
    {
        print("Warp");
    }
    public void Warp(Transform warpBall)
    {
        transform.position=warpBall.position+new Vector3(0,warpOffsetY,0);
    }
}
