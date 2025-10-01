using UnityEngine;

public class Conditionals : MonoBehaviour
{
    public int playerHealth = 1000;
    public bool playerAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerHealth--;
        print(playerHealth);

        if (playerHealth <= 0)
        {
            playerAlive = false;
            playerHealth = 0;
        }

        if (playerAlive)
        {
            print("I am alive");
        }
    }
}
