using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter()
    {
        Destroy(player);
        player.transform.position = spawn.transform.position;
        Debug.Log("died");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
