using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Spawner a ser congelado")]
    [Tooltip("Referência ao script de Spawner que será desabilitado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Tag de Verificação")]
    [Tooltip("Tag do objeto que, ao colidir, causará o congelamento do spawner.")]
    [SerializeField] private string asteroidTag = "Asteroid";

    [Header("Objeto Game Over")]
    [Tooltip("Referência ao objeto que será habilitado ao ocorrer o Game Over.")]
    [SerializeField] private GameObject gameOverUI;

    [Header("Audio Player")]
    [Tooltip("Referência ao script AudioPlayer.")]
    [SerializeField] private AudioPlayer audioPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(asteroidTag))
        {
            HandleGameOver(collision);
        }
    }

    private void HandleGameOver(Collision collision)
    {
        // Desabilita o script Asteroid Spawner se a referência estiver correta
        if (asteroidSpawnerScript != null)
        {
            if (asteroidSpawnerScript.enabled)
            {
                asteroidSpawnerScript.enabled = false;
            }
        }

        // Habilita o objeto de Game Over
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // Destrói todos os objetos com a tag "Asteroid"
        DestroyAllAsteroids();

        // Destrói o objeto que causou o Game Over
        Destroy(collision.gameObject);

        // Troca o áudio do jogo para o áudio de Game Over
        if (audioPlayer != null)
        {
            audioPlayer.StopMainGameAudio();
            audioPlayer.PlayGameOverAudio();
        }
    }

    private void DestroyAllAsteroids()
    {
        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag(asteroidTag))
        {
            Destroy(asteroid);
        }
    }
}
