using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Spawner a ser ativado")]
    [Tooltip("Refer�ncia ao script de Spawner que ser� ativado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Delay de Destrui��o")]
    [Tooltip("Tempo em segundos antes do objeto ser destru�do ap�s a colis�o.")]
    [SerializeField] private float destructionDelay = 0.1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            HandleCollisionWithLaser(collision);
        }
        else
        {
            Debug.Log($"Colis�o com objeto de tag diferente: {collision.gameObject.tag}");
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
                Debug.Log("Asteroid Spawner script j� est� habilitado.");
            }
        }
        else
        {
            Debug.LogWarning("Refer�ncia ao script Asteroid Spawner n�o est� atribu�da.");
        }

        // Destrua o objeto atual e a bala com um atraso
        Destroy(gameObject, destructionDelay);
        Destroy(collision.gameObject);
    }
}
