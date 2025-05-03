using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int totalScore = 0;

    public void UpdateScore(int scorePoints)
    {
        totalScore = totalScore + scorePoints;
        scoreText.text = totalScore.ToString();
    }

}
