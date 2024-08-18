using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Audio Player")]
    [Tooltip("Referência ao script AudioPlayer.")]
    [SerializeField] private AudioPlayer audioPlayer;

    [Header("Spawner a ser ativado")]
    [Tooltip("Referência ao script de Spawner que será ativado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Particle System")]
    [Tooltip("Referência ao ParticleSystem que será ativado.")]
    [SerializeField] private ParticleSystem particleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            HandleCollisionWithLaser();
        }
    }

    private void HandleCollisionWithLaser()
    {
        // Ativa o Spawner
        if (asteroidSpawnerScript != null)
        {
            asteroidSpawnerScript.enabled = true;
        }

        // Troca o áudio de introdução para o áudio principal do jogo
        if (audioPlayer != null)
        {
            audioPlayer.PlayRandomMainGameAudio(); // Atualize para o método correto
        }

        // Ativa o ParticleSystem
        if (particleSystem != null)
        {
            particleSystem.Play();
        }

        // Desativa o objeto StartGame
        gameObject.SetActive(false);
    }
}
