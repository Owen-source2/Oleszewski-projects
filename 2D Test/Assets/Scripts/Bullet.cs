using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set the speed of the bullet
        rb2d.linearVelocity = new Vector2(0, speed);
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bomb")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Bomb>().ResetPosition();
        }
    }
}
