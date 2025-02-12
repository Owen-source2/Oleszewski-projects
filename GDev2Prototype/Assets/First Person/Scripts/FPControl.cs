using UnityEngine;
using UnityEngine.InputSystem;
public class FPControl : MonoBehaviour
{
    CharacterController control;
    [SerializeField]GameObject camera;
    [SerializeField]GameObject bulletSpawner;
    [SerializeField]GameObject bullet;
    float cameraUpRotation=0;
    float cameraSideRotation=0;
    public float speed=1.0f;
    Vector2 charMove;
    Vector2 mouseMove;
    float mouseSensitivity = 100;
    [SerializeField]float mouseSensitivityX = 200;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        control=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mouseMove);
        float lookX = mouseMove.x*Time.deltaTime*mouseSensitivity;
        float lookY = mouseMove.y*Time.deltaTime*mouseSensitivity;
        cameraUpRotation-=lookY;
        cameraSideRotation-=lookX;
        cameraUpRotation=Mathf.Clamp(cameraUpRotation,-90,90);
        //cameraSideRotation=Mathf.Clamp(cameraSideRotation,-45,45);
        //Debug.Log(cameraUpRotation);
        //transform.Rotate(Vector3.up*lookX);
        

    }
    void FixedUpdate()
    {
        
        Vector3 realMove = new Vector3(charMove.x,0,charMove.y);
        control.Move(transform.rotation*realMove*speed);
    }
    void OnMove(InputValue movement)
    {
        charMove=movement.Get<Vector2>();
    }
    void OnLook(InputValue look)
    {
        //camera.transform.localRotation= Quaternion.Euler(cameraUpRotation,0,0);
        mouseMove=look.Get<Vector2>();
        mouseMove.Normalize();
        transform.Rotate(Vector3.up*mouseMove.x);
        //Debug.Log(mouseMove);
    }
    void OnAttack()
    {
        //bullet=Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        //Debug.Log(cameraUpRotation);
    }
}
