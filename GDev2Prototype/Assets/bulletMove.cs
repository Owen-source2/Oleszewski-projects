using UnityEngine;

public class bulletMove : MonoBehaviour
{
    [SerializeField]float bulletSpeed=5.0f;
    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = transform.position.normalized*bulletSpeed;
        rb.AddForce(move);
    }
}
