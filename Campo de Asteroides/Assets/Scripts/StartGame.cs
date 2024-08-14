using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
    [Header("Spawner a ser ativado")]
    [Tooltip("Referência ao script de Spawner que será ativado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Delay de Desativação")]
    [Tooltip("Tempo em segundos antes do objeto ser desativado após a colisão.")]
    [SerializeField] private float deactivationDelay = 0.1f;

    [Header("Game Controller")]
    [Tooltip("Referência ao script GameController para resetar o score.")]
    [SerializeField] private GameController gameController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            HandleCollisionWithLaser();
        }
        else
        {
            Debug.Log($"Colisão com objeto de tag diferente: {collision.gameObject.tag}");
        }
    }

    private void HandleCollisionWithLaser()
    {
        // Ativa o script Asteroid Spawner se a referência estiver correta
        if (asteroidSpawnerScript != null)
        {
            if (!asteroidSpawnerScript.enabled)
            {
                asteroidSpawnerScript.enabled = true;
                Debug.Log("Script Asteroid Spawner habilitado.");
            }
            else
            {
                Debug.Log("Script Asteroid Spawner já está habilitado.");
            }
        }
        else
        {
            Debug.LogWarning("Referência ao script Asteroid Spawner não está atribuída.");
        }

        // Reseta a pontuação através do GameController
        if (gameController != null)
        {
            gameController.ResetScore();
            Debug.Log("Pontuação resetada.");
        }
        else
        {
            Debug.LogWarning("Referência ao GameController não está atribuída.");
        }

        // Desativa o objeto atual após o atraso
        StartCoroutine(DeactivateObjectAfterDelay(deactivationDelay));
    }

    private IEnumerator DeactivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
