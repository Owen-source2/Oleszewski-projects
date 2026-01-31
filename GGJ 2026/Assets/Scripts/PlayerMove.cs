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
    public void Dash()
    {
        print("Dash");
    }
    public void Stomp()
    {
        print("Stomp");
    }
    public void Warp()
    {
        print("Warp");
    }
}
