using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
    [Header("Spawner a ser ativado")]
    [Tooltip("Refer�ncia ao script de Spawner que ser� ativado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Delay de Desativa��o")]
    [Tooltip("Tempo em segundos antes do objeto ser desativado ap�s a colis�o.")]
    [SerializeField] private float deactivationDelay = 0.1f;

    [Header("Game Controller")]
    [Tooltip("Refer�ncia ao script GameController para resetar o score.")]
    [SerializeField] private GameController gameController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            HandleCollisionWithLaser();
        }
        else
        {
            Debug.Log($"Colis�o com objeto de tag diferente: {collision.gameObject.tag}");
        }
    }

    private void HandleCollisionWithLaser()
    {
        // Ativa o script Asteroid Spawner se a refer�ncia estiver correta
        if (asteroidSpawnerScript != null)
        {
            if (!asteroidSpawnerScript.enabled)
            {
                asteroidSpawnerScript.enabled = true;
                Debug.Log("Script Asteroid Spawner habilitado.");
            }
            else
            {
                Debug.Log("Script Asteroid Spawner j� est� habilitado.");
            }
        }
        else
        {
            Debug.LogWarning("Refer�ncia ao script Asteroid Spawner n�o est� atribu�da.");
        }

        // Reseta a pontua��o atrav�s do GameController
        if (gameController != null)
        {
            gameController.ResetScore();
            Debug.Log("Pontua��o resetada.");
        }
        else
        {
            Debug.LogWarning("Refer�ncia ao GameController n�o est� atribu�da.");
        }

        // Desativa o objeto atual ap�s o atraso
        StartCoroutine(DeactivateObjectAfterDelay(deactivationDelay));
    }

    private IEnumerator DeactivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
