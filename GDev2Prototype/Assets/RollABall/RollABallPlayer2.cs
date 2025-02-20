using UnityEngine;
using UnityEngine.InputSystem;

public class RollABallPlayer2 : MonoBehaviour
{
    [SerializeField]GameObject player;
    Vector2 m;
    Rigidbody body;
    public float accelarate = 0.0f;
    public GameObject camera;
    public float turnspeed=1.0f;
    public float gravconst =-10.0f;
    public GameObject spawn;
    Vector3 groundNormal = new Vector3(0,0,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Vector3 vel=GetComponent<Rigidbody.velocity>();
        m=new Vector2(0,0); 
        body=GetComponent<Rigidbody>();
    }
    Vector3 checkGroundNormal()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 20))
        {
            if(hit.transform.gameObject.tag==("Ground"))
            {
                groundNormal=hit.normal;
                print(groundNormal);
                return(groundNormal);
            }
            else
            {
                return groundNormal;
            }
        }
        else if(Physics.SphereCast(transform.position, 10, transform.position, out hit, 10))
        {
            if(hit.transform.gameObject.tag==("Ground"))
            {
                groundNormal=hit.normal;
                print(groundNormal);
                return(groundNormal);
            }
            else
            {
                return groundNormal;
            }
        }
        else
        {
            return new Vector3(0,1,0);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        checkGroundNormal();
        float xDir = m.x;
        float zDir = m.y;
        Vector3 actualMovement = new Vector3(xDir,0,zDir);
        //actualMovement=Vector3.Scale(actualMovement.normalized,camera.transform.forward);
        //Debug.Log(camera.transform.forward);
        Vector3 camEulers = camera.transform.eulerAngles;

        //Quaternion targetRot=Quaternion.FromToRotation(transform.up,hit.normal)*transform.rotation;
        //transform.rotation=Quaternion.RotateTowards(transform.rotation, targetRot, turnspeed * Time.deltaTime);
        player.transform.up=checkGroundNormal();
        actualMovement = player.transform.rotation * actualMovement;
        body.AddForce(actualMovement*accelarate);
        Vector3 down = player.transform.up * -1;
        body.AddForce(Gravity(down, gravconst));

        //player.transform.Rotate(checkGroundNormal().x,0,checkGroundNormal().z);
    }
    
    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();

    }
    public void Respawn()
    {
        player.transform.position = spawn.transform.position;
    }
    Vector3 Gravity(Vector3 down, float weight)
    {   
        Vector3 gravity = down.normalized;
        gravity = gravity * weight;
        return gravity*-1;
    }
}
