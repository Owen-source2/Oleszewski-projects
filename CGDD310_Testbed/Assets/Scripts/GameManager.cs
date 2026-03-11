using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance1;
    public GameObject tornado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        /*if (GameManager.instance1 == null)
        {
            GameManager.instance1=this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            print(instance1.gameObject);
            Destroy(this.gameObject);
        }*/
    }
    void Start()
    {
        //tornado=GameObject.Find("Tornado");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartTornado()
    {
        tornado.SetActive(true);
    }
}
