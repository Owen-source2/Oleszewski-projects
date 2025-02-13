using UnityEngine;

public class bulletMove : MonoBehaviour
{
    [SerializeField]float bulletSpeed=5.0f;
    [SerializeField] Rigidbody rb;
    private float waitTime = 2.0f;
    private float timer = 0.0f;
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
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            timer = timer - waitTime;
            Destroy(gameObject);
        }

    }
}
