using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Spawner a ser congelado")]
    [Tooltip("Referência ao script de Spawner que será desabilitado.")]
    [SerializeField] private AsteroidSpawner asteroidSpawnerScript;

    [Header("Tag de Verificação")]
    [Tooltip("Tag do objeto que, ao colidir, causará o congelamento do spawner.")]
    [SerializeField] private string asteroidTag = "Asteroid";

    [Header("Objeto Game Over")]
    [Tooltip("Referência ao objeto que será habilitado ao ocorrer o Game Over.")]
    [SerializeField] private GameObject gameOverUI;

    [Header("Audio Player")]
    [Tooltip("Referência ao script AudioPlayer.")]
    [SerializeField] private AudioPlayer audioPlayer;

    [Header("Particle Systems Prefabs")]
    [Tooltip("Prefabs dos Particle Systems que serão ativados no Game Over.")]
    [SerializeField] private ParticleSystem particleSystemPrefab1;
    [SerializeField] private ParticleSystem particleSystemPrefab2;
    [SerializeField] private ParticleSystem particleSystemPrefab3;

    [Header("Objeto a ser alterado")]
    [Tooltip("Objeto que terá o MeshRenderer do filho desativado manualmente ao ocorrer o Game Over.")]
    [SerializeField] private GameObject objectToDisableMeshRenderer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(asteroidTag))
        {
            HandleGameOver(collision);
        }
    }

    private void HandleGameOver(Collision collision)
    {
        // Desabilita o script Asteroid Spawner se a referência estiver correta
        if (asteroidSpawnerScript != null && asteroidSpawnerScript.enabled)
        {
            asteroidSpawnerScript.enabled = false;
        }

        // Habilita o objeto de Game Over
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // Destrói todos os objetos com a tag "Asteroid"
        DestroyAllAsteroids();

        // Posiciona e ativa os Particle Systems clonados
        ActivateParticleSystems();

        // Desativa o MeshRenderer do filho do objeto manualmente escolhido
        if (objectToDisableMeshRenderer != null)
        {
            MeshRenderer childMeshRenderer = objectToDisableMeshRenderer.GetComponentInChildren<MeshRenderer>();
            if (childMeshRenderer != null)
            {
                childMeshRenderer.enabled = false;
            }
        }

        // Destrói o objeto que causou o Game Over
        Destroy(collision.gameObject);

        // Troca o áudio do jogo para o áudio de Game Over
        if (audioPlayer != null)
        {
            audioPlayer.StopMainGameAudio();
            audioPlayer.PlayGameOverAudio();
        }
    }

    private void DestroyAllAsteroids()
    {
        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag(asteroidTag))
        {
            Destroy(asteroid);
        }
    }

    private void ActivateParticleSystems()
    {
        if (objectToDisableMeshRenderer != null)
        {
            Vector3 objectPosition = objectToDisableMeshRenderer.transform.position;
            Quaternion objectRotation = objectToDisableMeshRenderer.transform.rotation;

            // Instancia e ativa os Particle Systems na posição e rotação do objeto a ser alterado
            if (particleSystemPrefab1 != null)
            {
                ParticleSystem particleClone1 = Instantiate(particleSystemPrefab1, objectPosition, objectRotation);
                particleClone1.Play();
                Destroy(particleClone1.gameObject, particleClone1.main.duration); // Destroi o clone após a duração das partículas
            }
            if (particleSystemPrefab2 != null)
            {
                ParticleSystem particleClone2 = Instantiate(particleSystemPrefab2, objectPosition, objectRotation);
                particleClone2.Play();
                Destroy(particleClone2.gameObject, particleClone2.main.duration); // Destroi o clone após a duração das partículas
            }
            if (particleSystemPrefab3 != null)
            {
                ParticleSystem particleClone3 = Instantiate(particleSystemPrefab3, objectPosition, objectRotation);
                particleClone3.Play();
                Destroy(particleClone3.gameObject, particleClone3.main.duration); // Destroi o clone após a duração das partículas
            }
        }
    }
}
