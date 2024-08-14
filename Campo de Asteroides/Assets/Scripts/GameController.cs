using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Record Components")]
    [SerializeField] private TextMeshProUGUI recordText;

    private float currentFillAmount = 1f;
    private int playerScore;
    private int recordScore;

    private void Start()
    {
        // Carrega o recorde salvo (se existir)
        recordScore = PlayerPrefs.GetInt("RecordScore", 0);
        recordText.text = recordScore.ToString();
    }

    public void UpdatePlayerScore(int points)
    {
        playerScore += points;
        scoreText.text = playerScore.ToString();

        // Atualiza o recorde se a nova pontuação for maior
        if (playerScore > recordScore)
        {
            recordScore = playerScore;
            recordText.text = recordScore.ToString();

            // Salva o novo recorde
            PlayerPrefs.SetInt("RecordScore", recordScore); // Corrigido aqui
            PlayerPrefs.Save();
        }
    }

    public void ResetScore()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
    }
}
