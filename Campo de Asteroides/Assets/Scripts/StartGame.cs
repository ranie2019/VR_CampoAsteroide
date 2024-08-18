using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Audio Player")]
    [Tooltip("Refer�ncia ao script AudioPlayer.")]
    [SerializeField] private AudioPlayer audioPlayer;

    [Header("Spawner a ser ativado")]
    [Tooltip("Refer�ncia ao script de Spawner que ser� ativado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Particle System")]
    [Tooltip("Refer�ncia ao ParticleSystem que ser� ativado.")]
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

        // Troca o �udio de introdu��o para o �udio principal do jogo
        if (audioPlayer != null)
        {
            audioPlayer.PlayRandomMainGameAudio(); // Atualize para o m�todo correto
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
