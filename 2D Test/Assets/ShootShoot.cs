using UnityEngine;

public class ShootShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        }
    }
}
