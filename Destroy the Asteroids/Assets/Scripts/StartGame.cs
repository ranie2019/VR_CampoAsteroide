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

    [Header("Game Controller")]
    [Tooltip("Referência ao script GameController.")]
    [SerializeField] private GameController gameController;

    [Header("Mesh Renderer")]
    [Tooltip("Referência ao MeshRenderer do objeto filho.")]
    [SerializeField] private MeshRenderer childMeshRenderer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            HandleCollisionWithLaser();
        }
    }

    private void HandleCollisionWithLaser()
    {
        // Reseta a pontuação do jogador
        if (gameController != null)
        {
            gameController.ResetScore();
        }

        // Ativa o Spawner
        if (asteroidSpawnerScript != null)
        {
            asteroidSpawnerScript.enabled = true;
        }

        // Troca o áudio de introdução para o áudio principal do jogo
        if (audioPlayer != null)
        {
            audioPlayer.PlayRandomMainGameAudio();
        }

        // Ativa o ParticleSystem
        if (particleSystem != null)
        {
            particleSystem.Play();
        }

        // Habilita o MeshRenderer do objeto filho
        if (childMeshRenderer != null)
        {
            childMeshRenderer.enabled = true;
        }

        // Desativa o objeto StartGame
        gameObject.SetActive(false);
    }
}
