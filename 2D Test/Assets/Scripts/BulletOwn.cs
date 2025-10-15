using UnityEngine;

public class BulletOwn : MonoBehaviour
{
    public float initVel;
    public Rigidbody2D body;
    public float lifeTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body.AddForce(new Vector2(initVel, 0));
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if(lifeTimer<=0)
        {
            Destroy(gameObject);
        }

        //body.AddForce(new Vector2(initVel, 0));
    }
}
