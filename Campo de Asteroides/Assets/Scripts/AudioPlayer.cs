using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Audio Source")]
    [Tooltip("Referência ao AudioSource que tocará os áudios.")]
    [SerializeField] private AudioSource audioSource;

    [Header("Audio Clips")]
    [Tooltip("Áudio de introdução que será tocado no início do jogo.")]
    [SerializeField] private AudioClip introClip;
    [Tooltip("Áudio principal do jogo que será tocado após a introdução.")]
    [SerializeField] private AudioClip mainGameClip;
    [Tooltip("Áudio de Game Over que será tocado quando o jogo terminar.")]
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
            audioSource.loop = false; // O áudio de introdução não deve repetir
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource ou IntroClip não atribuído.");
        }
    }

    public void PlayMainGameAudio()
    {
        if (audioSource != null && mainGameClip != null)
        {
            audioSource.clip = mainGameClip;
            audioSource.loop = true; // O áudio principal pode repetir
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource ou MainGameClip não atribuído.");
        }
    }

    public void PlayGameOverAudio()
    {
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.clip = gameOverClip;
            audioSource.loop = false; // O áudio de Game Over não deve repetir
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource ou GameOverClip não atribuído.");
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
