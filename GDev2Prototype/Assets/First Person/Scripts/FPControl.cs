using UnityEngine;
using UnityEngine.InputSystem;
public class FPControl : MonoBehaviour
{
    CharacterController control;
    [SerializeField]GameObject camera;
    [SerializeField]GameObject bulletSpawner;
    [SerializeField]GameObject bullet;
    float cameraUpRotation=0;
    public float speed=1.0f;
    Vector2 m = new Vector2(0,0);
    Vector2 mouseMove = new Vector2(0,0);
    float mouseSensitivity = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        control=GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float lookX = mouseMove.x*mouseSensitivity;
        float lookY = mouseMove.y*mouseSensitivity;
        cameraUpRotation-=lookY;
        cameraUpRotation=Mathf.Clamp(cameraUpRotation,-90,90);
        camera.transform.localRotation= Quaternion.Euler(cameraUpRotation,0,0);
        Vector3 realMove = new Vector3(m.x,0,m.y);
        control.Move(realMove*speed);

    }
    void OnMove(InputValue movement)
    {
        m=movement.Get<Vector2>();
    }
    void OnLook(InputValue look)
    {
        Vector2 mouseMove=look.Get<Vector2>();
    }
    void OnAttack()
    {
        bullet=Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }
}
