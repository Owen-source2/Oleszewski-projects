using UnityEngine;
using UnityEngine.InputSystem;
public class KinematicMomentum : MonoBehaviour
{
    CharacterController control;
    public float accelaration = 0.1f;
    public float deceleration = 0.05f;
    public float baseSpeed = 2.0f;
    public float topSpeed = 15.0f;
    float currentSpeed;
    public float fallSpeed = -10.0f;
    Vector2 charMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = baseSpeed;
        control=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

        Moving();
        Gravity();
    }
    void Gravity()
    {
        control.Move(transform.up*fallSpeed);
    }
    void Moving()
    {
        Vector3 realMove = new Vector3(charMove.x,0,charMove.y);
        if(currentSpeed <= topSpeed && charMove.magnitude >= 0.1)
        {
            currentSpeed=currentSpeed+accelaration;
            control.Move(transform.rotation*realMove*currentSpeed);
            transform.forward=Vector3.Lerp(transform.forward,realMove,0.6f);
        }
        else if(currentSpeed>=0 && charMove.magnitude < 0.1)
        {
            currentSpeed=currentSpeed-deceleration;
            control.Move(transform.forward*currentSpeed);
        }
        //print(transform.rotation*realMove*currentSpeed);
        
    }
    void OnMove(InputValue movement)
    {
        charMove=movement.Get<Vector2>();
    }
}
