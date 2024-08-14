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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(asteroidTag))
        {
            HandleGameOver(collision);
        }
        else
        {
            Debug.Log($"Colisão com objeto de tag diferente: {collision.gameObject.tag}");
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
                Debug.Log("Script Asteroid Spawner foi desabilitado.");
            }
            else
            {
                Debug.LogWarning("Script Asteroid Spawner já está desabilitado.");
            }
        }
        else
        {
            Debug.LogError("Referência ao script Asteroid Spawner está faltando!");
        }

        // Habilita o objeto de Game Over
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Debug.Log("Objeto Game Over habilitado.");
        }

        // Destrói todos os objetos com a tag "Asteroid"
        DestroyAllAsteroids();

        // Destrói o objeto que causou o Game Over
        Destroy(collision.gameObject);
        Debug.Log($"Objeto {collision.gameObject.name} destruído.");
    }

    private void DestroyAllAsteroids()
    {
        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag(asteroidTag))
        {
            Destroy(asteroid);
            Debug.Log($"Asteroide {asteroid.name} destruído.");
        }
    }
}
