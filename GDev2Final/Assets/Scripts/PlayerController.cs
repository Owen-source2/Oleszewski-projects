using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Vector2 DI;
    Rigidbody rb;
    public float accelerate = 1.0f;
    public float maxSpeed = 20.0f;
    public float jumpStrength = 2000.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DI = new Vector2(0,0);
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = DI.x;
        float zDir = DI.y;
        Vector3 finalDir = new Vector3(xDir,0,zDir);
        //if(Vector3.Magnitude(finalDir)*accelerate<=maxSpeed)
        {
            rb.AddForce(finalDir*accelerate);
        }
        
    }
    void OnMove(InputValue stickMove)
    {
        
        DI=stickMove.Get<Vector2>();
        print(DI);
    }
    void OnJump(InputAction jump)
    {
        rb.AddForce(0,jumpStrength,0);
    }
}
