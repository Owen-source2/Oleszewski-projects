using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int speed = 10;

    public Vector2 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForceX(speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForceX(-speed);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trap")
        {
            transform.position = startPos;
        }
    }
}
