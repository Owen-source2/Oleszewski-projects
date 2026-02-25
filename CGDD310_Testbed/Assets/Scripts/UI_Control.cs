using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_Control : MonoBehaviour
{
    public int SceneToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene(int toLoad)
    {
        SceneManager.LoadScene(toLoad);
    }
}
