using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject oldCamera;
    public GameObject newCamera;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter()
    {
        oldCamera.SetActive(false);
        newCamera.SetActive(true);
        

    }
}
