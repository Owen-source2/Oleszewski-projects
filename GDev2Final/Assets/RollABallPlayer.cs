using UnityEngine;
using UnityEngine.InputSystem;

public class RollABallPlayer : MonoBehaviour
{
    [SerializeField]GameObject player;
    Vector2 m;
    Rigidbody body;
    Vector3 vel=GetComponent<Rigidbody.velocity>();
    public GameObject camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       m=new Vector2(0,0); 
       body=GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xDir = m.x;
        float zDir = m.y;
        Vector3 actualMovement = new Vector3(xDir,0,zDir);
        print(actualMovement);

        body.AddForce(actualMovement*2 * camera.GetComponent<Transform.forward>());

    }
    
    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();

    }
}
