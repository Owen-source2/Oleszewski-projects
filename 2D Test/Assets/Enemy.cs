using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public UI_Control scoreboard;
    public int bounty = 500;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        rb2d.linearVelocity = Vector2.zero;
        float newX = Random.Range(-8, 8);
        float newY = Random.Range(6, 8);
        transform.position = new Vector2(newX, newY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            scoreboard.updateScore(bounty);
            Reset();
            Destroy(collision.gameObject);
        }
    }
}
