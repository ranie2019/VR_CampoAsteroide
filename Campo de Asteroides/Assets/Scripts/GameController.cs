using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Configura��es do Temporizador")]
    [Tooltip("Imagem usada como o temporizador visual.")]
    [SerializeField] private Image timerImage;

    [Tooltip("Dura��o total do jogo em segundos.")]
    [SerializeField] private float gameTime = 60f;

    private float remainingTime;

    private void Start()
    {
        // Inicializa o tempo restante como o tempo total de jogo
        remainingTime = gameTime;

        // Garante que a barra de tempo esteja cheia no in�cio
        timerImage.fillAmount = 1f;
    }

    private void Update()
    {
        // Atualiza o temporizador
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        // Diminui o tempo restante a cada frame
        remainingTime -= Time.deltaTime;

        // Calcula o preenchimento da imagem com base no tempo restante
        timerImage.fillAmount = remainingTime / gameTime;

        // Verifica se o tempo acabou
        if (remainingTime <= 0f)
        {
            TimerEnded();
        }
    }

    private void TimerEnded()
    {
        // Adicione a l�gica para o final do temporizador
        Debug.Log("O tempo acabou!");
        // Aqui voc� pode adicionar o que deve acontecer quando o tempo terminar
        // Exemplo: terminar o jogo, reiniciar a cena, etc.
    }
}
