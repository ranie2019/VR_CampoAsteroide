using UnityEngine;
using TMPro;

public class AsteroidHit : MonoBehaviour
{
    [Header("Configurações de Destruição")]
    [SerializeField] private GameObject asteroidExplosion;
    [SerializeField] private float explosionLifetime = 2f;
    [SerializeField] private float asteroidDestroyDelay = 0f;

    [Header("Referências Externas")]
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject popupCanvas;

    private void Awake()
    {
        gameController = FindAnyObjectByType<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            HandleAsteroidDestruction();
            Destroy(collision.gameObject);
        }
    }

    private void HandleAsteroidDestruction()
    {
        CreateExplosion();
        int asteroidScore = CalculateScore();
        ShowScorePopup(asteroidScore);
        gameController.UpdatePlayerScore(asteroidScore);
        Destroy(gameObject, asteroidDestroyDelay);
    }

    private void CreateExplosion()
    {
        if (asteroidExplosion != null)
        {
            GameObject explosion = Instantiate(asteroidExplosion, transform.position, transform.rotation);
            Destroy(explosion, explosionLifetime);
        }
    }

    private int CalculateScore()
    {
        float distanceFromCenter = Vector3.Distance(transform.position, Vector3.zero);
        return Mathf.Max(1, (int)distanceFromCenter);  // Pontuação mínima de 1
    }

    private void ShowScorePopup(int score)
    {
        if (popupCanvas != null)
        {
            GameObject asteroidPopup = Instantiate(popupCanvas, transform.position, Quaternion.identity);
            TextMeshProUGUI scoreText = asteroidPopup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            scoreText.text = score.ToString();

            float scaleMultiplier = Vector3.Distance(transform.position, Vector3.zero) / 10f;
            asteroidPopup.transform.localScale = transform.localScale * scaleMultiplier;
        }
    }
}
