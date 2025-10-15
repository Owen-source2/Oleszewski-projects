using UnityEngine;
using TMPro;

public class PlayerMover : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int speed = 10;
    public bool isAlive = true;
    public Vector2 startPos;
    public int playerHealth = 10;

    public TextMeshProUGUI winMsg;
    public TextMeshProUGUI playerHealth_Txt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            //movement code
            if (Input.GetKey(KeyCode.D))
            {
                rb2d.AddForceX(speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb2d.AddForceX(-speed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb2d.AddForceY(speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb2d.AddForceY(-speed);
            }
        }
        else
        {
            print("you have died");
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "trap")
        {

            if (playerHealth > 1)
            {
                playerHealth--;
                playerHealth_Txt.text = playerHealth.ToString();
            }
            else
            {
                transform.position = startPos;
                winMsg.text = "You Died!";
                isAlive = false;
            }

        }
    }
}
