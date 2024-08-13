using UnityEngine;
using TMPro;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    [SerializeField] private float explosionLifetime = 2f;
    [SerializeField] private float asteroidDestroyDelay = 0f;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject popupCanvas;

    private void Awake()
    {
        gameController =  FindAnyObjectByType<GameController>();
    }

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

    private void AsteroidDestroyed()
    {
        // Verifica se a explosão foi atribuída
        if (asteroidExplosion != null)
        {

            // Instancia a explosão na posição e rotação do asteroide
            GameObject explosion = Instantiate(asteroidExplosion, transform.position, transform.rotation);

            float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
            int bonusPOints = (int)distanceFromPlayer;

            int asteroidScore = 1 * bonusPOints;

            popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();

            GameObject asteroidPopup = Instantiate(popupCanvas, transform.position, Quaternion.identity);

            asteroidPopup.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 10),
                                                             transform.localScale.y * (distanceFromPlayer / 10),
                                                             transform.localScale.z * (distanceFromPlayer / 10));

            gameController.UpdadePlayerScore(asteroidScore);

            // Destrói a explosão após o tempo especificado
            Destroy(explosion, explosionLifetime);
        }

        // Destrói o asteroide após o delay especificado (se houver)
        Destroy(gameObject, asteroidDestroyDelay);
    }
}
