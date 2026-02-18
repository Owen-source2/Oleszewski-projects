using UnityEngine;

public class Tornado : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed=2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        rb2d.linearVelocityX=speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
