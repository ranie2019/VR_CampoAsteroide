using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Spawner a ser ativado")]
    [Tooltip("Refer�ncia ao script de Spawner que ser� ativado.")]
    [SerializeField] private GameObject asteroidSpawner;

    [Header("Delay de Destrui��o")]
    [Tooltip("Tempo em segundos antes do objeto ser destru�do ap�s a colis�o.")]
    [SerializeField] private float destructionDelay = 0.1f;

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto colidido tem a tag "Laser"
        if (collision.gameObject.CompareTag("Laser"))
        {
            // Habilita o Asteroid Spawner
            if (asteroidSpawner != null)
            {
                asteroidSpawner.SetActive(true);
            }

            // Destroi o objeto atual e a bala que colidiu ap�s um pequeno delay
            Destroy(gameObject, destructionDelay);
            Destroy(collision.gameObject);
        }
    }
}
