using UnityEngine;

public class EnemyFPS : MonoBehaviour
{

    public Animator enemyAnim;
    public Transform target;
    public float speed = 1.0f;
    [SerializeField]GameObject bullet;
    private float waitTime = 2.0f;
    private float timer = 0.0f;
    [SerializeField] Vector3 bulletDistance = new Vector3();
    public bool preparingToShoot=true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target=GameObject.Find("PlayerHeader(Clone)/FPPlayer").transform;
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        timer += Time.deltaTime;
        
        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            enemyAnim.SetBool("preparingToShoot", false);
            timer = timer - waitTime;
            Fire();
        }
        else
        {
            enemyAnim.SetBool("preparingToShoot",true);
        }
    }

    void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        //Destroy(bullet,1.0f);
    }
}
