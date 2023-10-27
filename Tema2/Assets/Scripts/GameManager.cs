using UnityEngine;
using TMPro;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreText;

    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

    }
}
