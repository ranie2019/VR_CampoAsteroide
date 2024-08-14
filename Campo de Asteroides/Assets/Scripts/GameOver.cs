using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Spawner a ser congelado")]
    [Tooltip("Refer�ncia ao script de Spawner que ser� desabilitado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Tag de Verifica��o")]
    [Tooltip("Tag do objeto que, ao colidir, causar� o congelamento do spawner.")]
    [SerializeField] private string asteroidTag = "Asteroid";

    [Header("Objeto Game Over")]
    [Tooltip("Refer�ncia ao objeto que ser� habilitado ao ocorrer o Game Over.")]
    [SerializeField] private GameObject gameOverUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(asteroidTag))
        {
            HandleGameOver(collision);
        }
        else
        {
            Debug.Log($"Colis�o com objeto de tag diferente: {collision.gameObject.tag}");
        }
    }

    private void HandleGameOver(Collision collision)
    {
        // Desabilita o script Asteroid Spawner se a refer�ncia estiver correta
        if (asteroidSpawnerScript != null)
        {
            if (asteroidSpawnerScript.enabled)
            {
                asteroidSpawnerScript.enabled = false;
                Debug.Log("Script Asteroid Spawner foi desabilitado.");
            }
            else
            {
                Debug.LogWarning("Script Asteroid Spawner j� est� desabilitado.");
            }
        }
        else
        {
            Debug.LogError("Refer�ncia ao script Asteroid Spawner est� faltando!");
        }

        // Habilita o objeto de Game Over
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Debug.Log("Objeto Game Over habilitado.");
        }

        // Destr�i todos os objetos com a tag "Asteroid"
        DestroyAllAsteroids();

        // Destr�i o objeto que causou o Game Over
        Destroy(collision.gameObject);
        Debug.Log($"Objeto {collision.gameObject.name} destru�do.");
    }

    private void DestroyAllAsteroids()
    {
        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag(asteroidTag))
        {
            Destroy(asteroid);
            Debug.Log($"Asteroide {asteroid.name} destru�do.");
        }
    }
}
