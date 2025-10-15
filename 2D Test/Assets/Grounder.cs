using UnityEngine;

public class Grounder : MonoBehaviour
{
    public UI_Control lives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Reset();
            lives.updateLives(1);
        }
    }

}
