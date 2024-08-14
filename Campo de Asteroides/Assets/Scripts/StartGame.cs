using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Spawner a ser ativado")]
    [Tooltip("Referência ao script de Spawner que será ativado.")]
    [SerializeField] private GameObject asteroidSpawner;

    [Header("Delay de Destruição")]
    [Tooltip("Tempo em segundos antes do objeto ser destruído após a colisão.")]
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

            // Destrói o objeto atual (que possui o script StartGame)
            Destroy(gameObject, destructionDelay);

            // Destrói o objeto que colidiu (neste caso, o "Laser")
            Destroy(collision.gameObject);
        }
    }
}
