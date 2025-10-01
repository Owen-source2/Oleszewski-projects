using UnityEngine;
public class FirstScript : MonoBehaviour
{
    public string playerName = "Jason";
    public bool hasPowerUp = false;
    public Vector2 ourPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("This Line prints first and once");
        print("This Line prints second and once");
        print(1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        print("This Line prints after the Start function and forever");
        print("And then its my turn");
        print(playerName);
    }


} // end of class
