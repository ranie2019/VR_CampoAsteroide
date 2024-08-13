using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configura��es da Bala")]
    [Tooltip("Velocidade da bala.")]
    public float bulletSpeed = 20f;

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
        else
        {
            Debug.LogError("Rigidbody n�o encontrado na bala!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Log da colis�o para depura��o
        Debug.Log("Bala colidiu com: " + collision.gameObject.name);

        // Log da velocidade da bala para depura��o
        if (rb != null)
        {
            Debug.Log("Velocidade da bala: " + rb.velocity);
        }

        // Verifica se o objeto colidido tem a tag "Asteroid"
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Atingiu um asteroide!");
            // Destr�i o asteroide
            Destroy(collision.gameObject);
        }

        // Destr�i a bala ap�s a colis�o
        Destroy(gameObject);
    }
}
