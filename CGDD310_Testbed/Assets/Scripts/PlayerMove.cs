using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public bool onGround, hurt=false;
    public LayerMask groundLayer;
    public GameObject groundCheckL, groundCheckR, spawnpoint, tornado, tornadoSpawnPoint;
    private InputAction moveAction, jumpAction;
    public float moveSpeed=5,jumpPower=10,iFrames=3;
    private bool jump=false;
    public Rigidbody2D rb2d;
    private static int nextScene;
    private Vector2 moveVector;
    public int health=5;
    SpriteRenderer sprite;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tornado=GameObject.Find("Tornado");
        tornadoSpawnPoint=GameObject.Find("TornadoSpawn");
        nextScene=SceneManager.GetActiveScene().buildIndex+1;
        moveAction=InputSystem.actions.FindAction("Move");
        jumpAction=InputSystem.actions.FindAction("Jump");
        sprite=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
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
        if (onGround)
        {
            anim.SetBool("OnGround",true);
            jump=jumpAction.IsPressed();
        }
        else
        {
            anim.SetBool("OnGround",false);
        }
        moveVector=moveAction.ReadValue<Vector2>();
        if (rb2d.linearVelocityX > 0)
        {
            sprite.flipX=false;
        }
        else if(moveVector.x<0)
        {
            sprite.flipX=true;
        }
        anim.SetFloat("XSpeed", Mathf.Abs(rb2d.linearVelocityX));
    }
    void FixedUpdate() {
        rb2d.linearVelocityX=moveVector.x*moveSpeed;
        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForceY(jumpPower,ForceMode2D.Impulse);
            jump=false;
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.GetComponent<KillPlayer>())
        {
            Die();
        }
        else if (collider2D.gameObject.GetComponent<EndGame>())
        {
            try{
                //nextScene++;
                print(nextScene);
                SceneManager.LoadScene(nextScene);
            }
            catch
            {
                nextScene=0;
                print(nextScene);
                SceneManager.LoadScene(nextScene);
            }
        }
        else if (collider2D.gameObject.GetComponent<Spawnpoint>())
        {
            spawnpoint=collider2D.gameObject;
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D) {
        if (collision2D.gameObject.GetComponent<HurtPlayer>()&&!hurt)
        {
            Hurt();
        }
    }
    void Hurt()
    {
        health--;
        StartCoroutine("IFrames");
        if (health <= 0)
        {
            Die();
        }
    }
    IEnumerator IFrames()
    {
        hurt=true;
        anim.SetBool("Hurt",true);
        yield return new WaitForSeconds(iFrames);
        anim.SetBool("Hurt",false);
        hurt=false;
    }
    void Die()
    {
        tornado.transform.position=tornadoSpawnPoint.transform.position;
        transform.position=spawnpoint.transform.position;
        health=5;
    }
}
