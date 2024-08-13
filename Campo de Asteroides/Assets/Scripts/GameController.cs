using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;
    private float sliderCurrentFillAmount = 1f;

    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private int playerScore;

    private void Update()
    {
        // Atualiza o temporizador
        AdjustTimer();
    }

    private void AdjustTimer()
    {
        timerImage.fillAmount = sliderCurrentFillAmount - (Time.deltaTime / gameTime);

        sliderCurrentFillAmount = timerImage.fillAmount;
    }

    public void UpdadePlayerScore(int asteroidHitPoints)
    {
        playerScore += asteroidHitPoints;
        scoreText.text = playerScore.ToString();
    }
}
