using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    [Header("Configurações de Destruição")]
    [Tooltip("Prefab da explosão a ser instanciada ao destruir o asteroide.")]
    [SerializeField] private GameObject asteroidExplosion;

    [Tooltip("Tempo de vida da explosão antes de ser destruída.")]
    [SerializeField] private float explosionLifetime = 2f;

    [Tooltip("Delay para destruir o asteroide após a explosão (se necessário).")]
    [SerializeField] private float asteroidDestroyDelay = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto com o qual o asteroide colidiu tem a tag "Laser"
        if (collision.gameObject.CompareTag("Laser"))
        {
            // Destrói o asteroide e instancia a explosão
            AsteroidDestroyed();

            // Destrói a bala após a colisão
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// Destrói o asteroide e instancia a explosão.
    /// </summary>
    private void AsteroidDestroyed()
    {
        // Verifica se a explosão foi atribuída
        if (asteroidExplosion != null)
        {
            // Instancia a explosão na posição e rotação do asteroide
            GameObject explosion = Instantiate(asteroidExplosion, transform.position, transform.rotation);

            // Destrói a explosão após o tempo especificado
            Destroy(explosion, explosionLifetime);
        }

        // Destrói o asteroide após o delay especificado (se houver)
        Destroy(gameObject, asteroidDestroyDelay);
    }
}
