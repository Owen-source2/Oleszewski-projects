using UnityEngine;

public class PlayerMover_LR : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int speed = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //movement code
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForceX(speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForceX(-speed);
        }
        else
        {
            rb2d.linearVelocity = Vector2.zero;
        }
    }
}
