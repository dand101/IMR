using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

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
        Debug.Log("Score: " + score); 
    }
}
