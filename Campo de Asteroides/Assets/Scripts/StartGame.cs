using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Spawner a ser ativado")]
    [Tooltip("Referência ao script de Spawner que será ativado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Delay de Destruição")]
    [Tooltip("Tempo em segundos antes do objeto ser destruído após a colisão.")]
    [SerializeField] private float destructionDelay = 0.1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            HandleCollisionWithLaser(collision);
        }
        else
        {
            Debug.Log($"Colisão com objeto de tag diferente: {collision.gameObject.tag}");
        }
    }

    private void HandleCollisionWithLaser(Collision collision)
    {
        if (asteroidSpawnerScript != null)
        {
            if (!asteroidSpawnerScript.enabled)
            {
                asteroidSpawnerScript.enabled = true;
                Debug.Log("Asteroid Spawner script habilitado.");
            }
            else
            {
                Debug.Log("Asteroid Spawner script já está habilitado.");
            }
        }
        else
        {
            Debug.LogWarning("Referência ao script Asteroid Spawner não está atribuída.");
        }

        // Destrua o objeto atual e a bala com um atraso
        Destroy(gameObject, destructionDelay);
        Destroy(collision.gameObject);
    }
}
