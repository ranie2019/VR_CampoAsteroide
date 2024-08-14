using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configurações da Bala")]
    [Tooltip("Velocidade da bala.")]
    [SerializeField] private float bulletSpeed = 20f;

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
        else
        {
            Debug.LogError("Rigidbody não encontrado na bala!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Log da colisão para depuração
        HandleCollision(collision);
    }

    private void HandleCollision(Collision collision)
    {
        // Log da colisão
        Debug.Log($"Bala colidiu com: {collision.gameObject.name}");

        // Log da velocidade da bala
        Debug.Log($"Velocidade da bala: {rb?.velocity}");

        // Verifica se o objeto colidido tem a tag "Asteroid"
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Atingiu um asteroide!");
            Destroy(collision.gameObject);
        }

        // Destrói a bala após a colisão
        Destroy(gameObject);
    }
}
