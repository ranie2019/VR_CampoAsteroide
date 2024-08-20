using UnityEngine;
using System; // Adiciona a diretiva para usar a classe Array

public class AudioPlayer : MonoBehaviour
{
    [Header("Audio Source")]
    [Tooltip("Referência ao AudioSource que tocará os áudios.")]
    [SerializeField] private AudioSource audioSource;

    [Header("Audio Clips")]
    [Tooltip("Áudios de introdução que serão tocados no início do jogo.")]
    [SerializeField] private AudioClip[] introClips;
    [Tooltip("Áudios principais do jogo que serão tocados após a introdução.")]
    [SerializeField] private AudioClip[] mainGameClips;
    [Tooltip("Áudio de Game Over que será tocado quando o jogo terminar.")]
    [SerializeField] private AudioClip gameOverClip;

    private void Start()
    {
        PlayRandomIntroAudio();
    }

    private void PlayRandomIntroAudio()
    {
        if (audioSource != null && introClips.Length > 0)
        {
            AudioClip randomClip = introClips[UnityEngine.Random.Range(0, introClips.Length)];
            audioSource.clip = randomClip;
            audioSource.loop = false; // O áudio de introdução não deve repetir
            audioSource.Play();
        }
    }

    public void PlayRandomMainGameAudio()
    {
        if (audioSource != null && mainGameClips.Length > 0)
        {
            AudioClip randomClip = mainGameClips[UnityEngine.Random.Range(0, mainGameClips.Length)];
            audioSource.clip = randomClip;
            audioSource.loop = true; // O áudio principal pode repetir
            audioSource.Play();
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
    }

    public void StopMainGameAudio()
    {
        if (audioSource != null && audioSource.isPlaying && audioSource.clip != null && Array.Exists(mainGameClips, clip => clip == audioSource.clip))
        {
            audioSource.Stop();
        }
    }
}
