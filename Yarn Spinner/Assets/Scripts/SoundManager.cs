using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip goalSound;
    void OnDisable() {
        GameManager.instance.goal-=OnGoal; 
    }
    void Start() {
        GameManager.instance.goal+=OnGoal;
    }
    void OnGoal()
    {
        print("GOAL!!!");
        audioSource.PlayOneShot(goalSound);
    }
}
