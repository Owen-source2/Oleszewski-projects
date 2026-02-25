using UnityEngine;
using UnityEngine.Events;
public class Ball : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D goal) {
        if (goal.gameObject.GetComponent<Goal>())
        {
            GameManager.instance.goal.Invoke();
            transform.position=startPos;
            GameManager.instance.score++;
        }
        
    }
}
