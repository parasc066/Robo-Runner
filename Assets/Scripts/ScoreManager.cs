using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;
    int totalScore = 0;

    public void UpdateScore(int scorePoints)
    {
        if(gameManager.GameOver) return;
        
        totalScore = totalScore + scorePoints;
        scoreText.text = totalScore.ToString();
    }

}
