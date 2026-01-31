using UnityEngine;

public class WarpBall : MonoBehaviour
{
    public GameObject player;
    public PlayerMove playerMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        playerMove=player.GetComponent<PlayerMove>();
    }

    void OnCollisionEnter2D(Collision2D collision2D) {
        playerMove.Warp(transform);
        print(collision2D.transform);
        Destroy(gameObject);
    }
}
