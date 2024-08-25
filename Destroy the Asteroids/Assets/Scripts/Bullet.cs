using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configurações da Bala")]
    [Tooltip("Velocidade da bala.")]
    [SerializeField] private float bulletSpeed = 800f;

    private Rigidbody rb;

    private void Awake()
    {
        // Obtém o Rigidbody da bala
        rb = GetComponent<Rigidbody>();

        // Configura a velocidade da bala se o Rigidbody estiver presente
        if (rb != null)
        {
            rb.velocity = transform.forward * bulletSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Log da colisão para depuração
        HandleCollision(collision);
    }

    private void HandleCollision(Collision collision)
    {
        // Log para verificar a colisão
        Debug.Log($"Colidiu com: {collision.gameObject.name} - Tag: {collision.gameObject.tag}");

        // Verifica se o objeto colidido tem a tag "Asteroid"
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Destrói o objeto com a tag "Asteroid"
            Destroy(collision.gameObject);
        }

        // Destrói a bala após a colisão
        Destroy(gameObject);
    }
}
