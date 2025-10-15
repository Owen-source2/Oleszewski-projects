using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetPosition()
    {
        Vector2 resetPosition = new Vector2();
        resetPosition.x = Random.Range(-8, 8);
        resetPosition.y = Random.Range(6, 7);
        transform.position = resetPosition;
    }
}