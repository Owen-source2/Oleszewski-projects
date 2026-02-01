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
    float facingDir;
    [SerializeField]Transform warpBallSpawn;
    [SerializeField] GameObject warpBallBase;
    [SerializeField]int warpBallBaseSpeed;
    [SerializeField]float dashSpeed;
    public bool canDash;
    public float dashCooldown;
    PlayerStateMachine stateMachine;
    public int health;
    int maxHealth;
    public Transform lastCheckpoint;
    bool burning;
    public int baseBounceSpeed;
    public Vector2 lavaBounceSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth=health;
        stateMachine=gameObject.GetComponent<PlayerStateMachine>();
        canDash=true;
        gravity=rb2d.gravityScale;
        groundFriction=rb2d.linearDamping;
        facingDir=1.0f;
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
        if (health <= 0)
        {
            Die();
        }
        //print(onGround);
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
        if (Input.GetAxisRaw("Horizontal") >= 0.01f||Input.GetAxisRaw("Horizontal")<=-0.01f)
        {
            facingDir=Input.GetAxisRaw("Horizontal");
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
        if(canDash)
        {
            rb2d.linearVelocity=Vector2.zero;
            Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
            rb2d.linearVelocity=dir*dashSpeed;
            canDash=false;
            StartCoroutine("DashCooldown");        
        }
    }
    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash=true;
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
        GameObject warpBall=Instantiate(warpBallBase,warpBallSpawn.position,Quaternion.identity);
        warpBall.GetComponent<Rigidbody2D>().linearVelocity=(rb2d.linearVelocity*new Vector2(0.9f,0.7f))+new Vector2(facingDir*warpBallBaseSpeed,warpBallBaseSpeed/2);
    }
    public void Warp(Transform warpBall)
    {
        print("Warping to "+warpBall);
        transform.position=warpBall.position+new Vector3(0,warpOffsetY,0);
    }
    void OnCollisionEnter2D(Collision2D collision2D) {
        if (collision2D.transform.gameObject.GetComponent<Lava>())
        {
            stateMachine.playerState=PlayerStateMachine.PlayerState.Burning;
        }
        
    }
    void OnTriggerEnter2D(Collider2D collider2D) {
        
    
        if (collider2D.transform.gameObject.GetComponent<BouncePad>())
            {
                stateMachine.playerState=PlayerStateMachine.PlayerState.NoMask;
                Bounce();
            }
    }
    public void LavaBounce()
    {
        print("Burning");
        if (!burning)
        {
            health--;
            StartCoroutine("Burn");  
            rb2d.linearVelocity+=lavaBounceSpeed;
        }
        burning=true;
    }
    IEnumerator Burn()
    {
        yield return new WaitForSeconds(1);
        burning=false;
        onGround=false;
        stateMachine.playerState=PlayerStateMachine.PlayerState.NoMask;
    }
    void Die()
    {
        transform.position=lastCheckpoint.position;
        health=maxHealth;
        rb2d.linearVelocity=Vector2.zero;
    }
    void Bounce()
    {
        print(rb2d.linearVelocity);
        rb2d.linearVelocity*=new Vector2(1,-1)+new Vector2(0,baseBounceSpeed*-1);
        print(rb2d.linearVelocity);
    }
}
 