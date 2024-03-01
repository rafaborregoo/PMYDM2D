using UnityEngine;
using TMPro;

public class ScoreHUD : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
