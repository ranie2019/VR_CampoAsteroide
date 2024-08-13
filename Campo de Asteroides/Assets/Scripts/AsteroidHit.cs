using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    [Header("Configura��es de Destrui��o")]
    [Tooltip("Prefab da explos�o a ser instanciada ao destruir o asteroide.")]
    [SerializeField] private GameObject asteroidExplosion;

    [Tooltip("Tempo de vida da explos�o antes de ser destru�da.")]
    [SerializeField] private float explosionLifetime = 2f;

    [Tooltip("Delay para destruir o asteroide ap�s a explos�o (se necess�rio).")]
    [SerializeField] private float asteroidDestroyDelay = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto com o qual o asteroide colidiu tem a tag "Laser"
        if (collision.gameObject.CompareTag("Laser"))
        {
            // Destr�i o asteroide e instancia a explos�o
            AsteroidDestroyed();

            // Destr�i a bala ap�s a colis�o
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// Destr�i o asteroide e instancia a explos�o.
    /// </summary>
    private void AsteroidDestroyed()
    {
        // Verifica se a explos�o foi atribu�da
        if (asteroidExplosion != null)
        {
            // Instancia a explos�o na posi��o e rota��o do asteroide
            GameObject explosion = Instantiate(asteroidExplosion, transform.position, transform.rotation);

            // Destr�i a explos�o ap�s o tempo especificado
            Destroy(explosion, explosionLifetime);
        }

        // Destr�i o asteroide ap�s o delay especificado (se houver)
        Destroy(gameObject, asteroidDestroyDelay);
    }
}
