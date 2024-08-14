using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private float currentFillAmount = 1f;
    private int playerScore;

    public void UpdatePlayerScore(int points)
    {
        playerScore += points;
        scoreText.text = playerScore.ToString();
    }
}
