using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForceX(-speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForceX(speed);
        }
        else
        {
            PlayerStop();
        }
    }

    public void PlayerStop()
    {
        rb2d.linearVelocity = Vector2.zero;
        // play stop sound
        // play stop animation
    }
}
