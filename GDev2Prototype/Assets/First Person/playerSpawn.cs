using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    [SerializeField]GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player")==null)
        {
            Instantiate(player, transform.position, transform.rotation);
        }
    }
}
