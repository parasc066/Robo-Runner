using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;
    bool gameOver = false;

    // public bool GameOver {get{return gameOver;}}
    // public bool GameOver{get; private set;}
    public bool GameOver => gameOver;
    
    void Start()
    {
        timeLeft = startTime;
    }
    void Update()
    {
        DecreaseTime();
    }
    
    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }

    void DecreaseTime()
    {
        if(gameOver) return;
        timeLeft = timeLeft - Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
        
        if(timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }



    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;//disable player movement
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
