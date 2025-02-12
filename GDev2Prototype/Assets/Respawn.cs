using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn;
    [SerializeField] float lifetime=1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("died");
            print(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(collision.gameObject.tag!="Ground"&&collision.gameObject.tag!=gameObject.tag)
        {
            Destroy(collision.transform.gameObject);
            //player.transform.position = spawn.transform.position;
            
        }
        else if(collision.gameObject.tag=="Ground")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Destroy(gameObject,lifetime);
    }
}
