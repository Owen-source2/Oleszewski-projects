using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Control : MonoBehaviour
{
    public TMP_Text livesDisplay;
    public TMP_Text scoreDisplay;
    public int lives = 5;
    public int score = 0;
    int nextHighScore = 10000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateLives(0);
        updateScore(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updateLives(int damage)
    {
        lives -= damage;
        livesDisplay.text = "Health: " + lives;
        if (lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void updateScore(int points)
    {
        score += points;
        scoreDisplay.text = "Score: " + score + " points";
        if(score>=nextHighScore)
        {
            nextHighScore *= 2;
            updateLives(-1);
        }
    }
}
