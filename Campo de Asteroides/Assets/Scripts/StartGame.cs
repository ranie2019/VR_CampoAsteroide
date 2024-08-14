using UnityEngine;
using System.Collections; // Adicione esta diretiva

public class StartGame : MonoBehaviour
{
    [Header("Spawner a ser ativado")]
    [Tooltip("Refer�ncia ao script de Spawner que ser� ativado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Delay de Desativa��o")]
    [Tooltip("Tempo em segundos antes do objeto ser desativado ap�s a colis�o.")]
    [SerializeField] private float deactivationDelay = 0.1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            HandleCollisionWithLaser(collision);
        }
        else
        {
            Debug.Log($"Colis�o com objeto de tag diferente: {collision.gameObject.tag}");
        }
    }

    private void HandleCollisionWithLaser(Collision collision)
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

        // Desativa o objeto atual ap�s o atraso
        StartCoroutine(DeactivateObjectAfterDelay(deactivationDelay));

        // Destr�i o objeto que colidiu (neste caso, o "Laser")
        Destroy(collision.gameObject);
    }

    private IEnumerator DeactivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
