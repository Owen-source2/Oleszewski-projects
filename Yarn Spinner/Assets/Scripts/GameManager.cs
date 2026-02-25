using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score=0;
    public UnityAction goal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {


        //Destroy other GameManagers
        if (instance == null)
        {
            instance=this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
