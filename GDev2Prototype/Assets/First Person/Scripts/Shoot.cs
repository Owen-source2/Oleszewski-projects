using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnAttack()
    {

        /*RaycastHit hit;
        LayerMask mask=LayerMask.GetMask("Character");
        if (Physics.Raycast(transform.position,transform.forward, out hit,mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Destroy(hit.transform.gameObject);
        }
        else
        { 
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white); 
            Debug.Log("Did not Hit"); 
        }*/
        Debug.Log("shot");
        Instantiate(bullet, transform.position, transform.rotation);
        //Destroy(bullet,1.0f);

    }
}
