using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.GetComponent<KinematicMomentum>()!=null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
