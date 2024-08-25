using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configura��es da Bala")]
    [Tooltip("Velocidade da bala.")]
    [SerializeField] private float bulletSpeed = 800f;

    private Rigidbody rb;

    private void Awake()
    {
        // Obt�m o Rigidbody da bala
        rb = GetComponent<Rigidbody>();

        // Configura a velocidade da bala se o Rigidbody estiver presente
        if (rb != null)
        {
            rb.velocity = transform.forward * bulletSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Log da colis�o para depura��o
        HandleCollision(collision);
    }

    private void HandleCollision(Collision collision)
    {
        // Log para verificar a colis�o
        Debug.Log($"Colidiu com: {collision.gameObject.name} - Tag: {collision.gameObject.tag}");

        // Verifica se o objeto colidido tem a tag "Asteroid"
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Destr�i o objeto com a tag "Asteroid"
            Destroy(collision.gameObject);
        }

        // Destr�i a bala ap�s a colis�o
        Destroy(gameObject);
    }
}
