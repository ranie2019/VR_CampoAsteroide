using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Audio Source")]
    [Tooltip("Refer�ncia ao AudioSource que tocar� os �udios.")]
    [SerializeField] private AudioSource audioSource;

    [Header("Audio Clips")]
    [Tooltip("�udio de introdu��o que ser� tocado no in�cio do jogo.")]
    [SerializeField] private AudioClip introClip;
    [Tooltip("�udio principal do jogo que ser� tocado ap�s a introdu��o.")]
    [SerializeField] private AudioClip mainGameClip;
    [Tooltip("�udio de Game Over que ser� tocado quando o jogo terminar.")]
    [SerializeField] private AudioClip gameOverClip;

    private void Start()
    {
        PlayIntroAudio();
    }

    private void PlayIntroAudio()
    {
        if (audioSource != null && introClip != null)
        {
            audioSource.clip = introClip;
            audioSource.loop = false; // O �udio de introdu��o n�o deve repetir
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource ou IntroClip n�o atribu�do.");
        }
    }

    public void PlayMainGameAudio()
    {
        if (audioSource != null && mainGameClip != null)
        {
            audioSource.clip = mainGameClip;
            audioSource.loop = true; // O �udio principal pode repetir
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource ou MainGameClip n�o atribu�do.");
        }
    }

    public void PlayGameOverAudio()
    {
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.clip = gameOverClip;
            audioSource.loop = false; // O �udio de Game Over n�o deve repetir
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource ou GameOverClip n�o atribu�do.");
        }
    }

    public void StopMainGameAudio()
    {
        if (audioSource != null && audioSource.isPlaying && audioSource.clip == mainGameClip)
        {
            audioSource.Stop();
        }
    }
}
