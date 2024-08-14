using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Spawner a ser congelado")]
    [Tooltip("Refer�ncia ao script de Spawner que ser� congelado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawner;

    [Header("Tag de Verifica��o")]
    [Tooltip("Tag do objeto que, ao colidir, causar� o congelamento do spawner.")]
    [SerializeField] private string asteroidTag = "Asteroid";

    [Header("Objeto Game Over")]
    [Tooltip("Refer�ncia ao objeto que ser� habilitado ao ocorrer o Game Over.")]
    [SerializeField] private GameObject gameOverUI;

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto colidido tem a tag correta
        if (collision.gameObject.CompareTag(asteroidTag))
        {
            Debug.Log($"Colis�o detectada com: {collision.gameObject.name}, tag: {asteroidTag}");

            // Congela o Asteroid Spawner, desativando seu comportamento de spawn
            if (asteroidSpawner != null)
            {
                asteroidSpawner.enabled = false;
                Debug.Log("Asteroid Spawner foi congelado.");
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
        else
        {
            Debug.Log($"Colis�o com um objeto de tag diferente: {collision.gameObject.tag}");
        }
    }

    private void DestroyAllAsteroids()
    {
        // Encontra todos os objetos com a tag "Asteroid"
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag(asteroidTag);

        // Destr�i cada um dos asteroides encontrados
        foreach (GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
            Debug.Log($"Asteroide {asteroid.name} destru�do.");
        }
    }
}
