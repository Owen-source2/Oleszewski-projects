using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]GameObject bullet;
    private float waitTime = 2.0f;
    private float timer = 0.0f;
    [SerializeField] Vector3 bulletDistance = new Vector3();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            timer = timer - waitTime;
            Fire();
        }

    }
    void Fire()
    {
        bullet=Instantiate(bullet, transform.position, transform.rotation);
        //Destroy(bullet,1.0f);
    }
}
