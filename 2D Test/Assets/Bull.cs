using UnityEngine;

public class Bull : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d.linearVelocityY = speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
