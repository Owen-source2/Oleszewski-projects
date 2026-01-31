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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            onGround=false;
        }
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(0,jumpForce));
        }
        else
        {
            rb2d.linearVelocityY=Mathf.Clamp(rb2d.linearVelocityY,-terminalVel,terminalVel);
        }
        Debug.Log(onGround);
    }
    void FixedUpdate() 
    {
        rb2d.AddForce(Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw("Horizontal"),0)*speed,topHorizontalSpeed));
    }
}
