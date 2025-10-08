using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Rigidbody2D body;
    public Collider2D collision;
    public Vector2 posInit;
    public GameObject bullet;
    public float shootCooldown = 0.5f;
    float shootCooldownInit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootCooldownInit = shootCooldown;
        posInit = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shootCooldown += Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForceX(speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            body.AddForceX(-speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForceY(speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForceY(-speed);
        }
        if(Input.GetKey(KeyCode.Space)&&shootCooldown>=shootCooldownInit)
        {
            GameObject.Instantiate(bullet, gameObject.transform.position,gameObject.transform.rotation);
            shootCooldown = 0;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            gameObject.transform.position = posInit;
        }
    }
}
