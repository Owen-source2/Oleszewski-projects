using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Rigidbody2D body;
    public Collider2D collision;
    public Vector2 posInit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posInit = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            gameObject.transform.position = posInit;
        }
    }
}
