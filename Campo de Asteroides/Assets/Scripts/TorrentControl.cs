using UnityEngine;

public class TorrentControl : MonoBehaviour
{
    // Distância mínima para começar a seguir o asteroide
    public float distance = 50f;

    // Transforms que representam a montagem (mount) da torre, a cabeça da torre, e os pontos de anexo do projétil
    public Transform mount;
    public Transform head;
    public Transform[] attachPoints; // Array para armazenar múltiplos pontos de anexo

    // Propriedades para o projétil, a taxa de disparo e a velocidade do projétil
    public GameObject projectile;
    public float fireRate = 1f;
    public float projectileSpeed = 800f;

    // Componente de áudio para o som de disparo
    public AudioClip laserSFX;
    private AudioSource laserAudioSource;

    // Referência ao script TurrentAnimator para acionar animações
    private TurrentAnimator turrentAnimator;

    private Transform closestAsteroid;
    private float nextFireTime = 0f;
    private int currentAttachIndex = 0; // Índice para rastrear qual ponto de anexo usar

    private void Awake()
    {
        // Tenta obter o AudioSource automaticamente ou adiciona um novo
        laserAudioSource = GetComponent<AudioSource>();
        if (laserAudioSource == null)
        {
            laserAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // Atribui o AudioClip ao AudioSource e configura as propriedades do som
        if (laserSFX != null)
        {
            laserAudioSource.clip = laserSFX;
            laserAudioSource.playOnAwake = false;
        }

        // Obtém o script TurrentAnimator do objeto atual ou de um objeto filho
        turrentAnimator = GetComponentInChildren<TurrentAnimator>();
    }

    private void Update()
    {
        FindClosestAsteroid();

        if (closestAsteroid != null)
        {
            RotateTowardsAsteroid();

            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + 1f / fireRate;
                ShootProjectile();
            }
        }
    }

    // Encontra o asteroide mais próximo dentro do alcance
    private void FindClosestAsteroid()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        float closestDistance = Mathf.Infinity;

        foreach (GameObject asteroid in asteroids)
        {
            float dist = Vector3.Distance(asteroid.transform.position, transform.position);

            if (dist < closestDistance && dist < distance)
            {
                closestDistance = dist;
                closestAsteroid = asteroid.transform;
            }
        }
    }

    // Faz a montagem (mount) da torre rotacionar no eixo Y e a cabeça no eixo X em direção ao asteroide mais próximo
    private void RotateTowardsAsteroid()
    {
        if (closestAsteroid != null)
        {
            Vector3 directionToAsteroid = closestAsteroid.position - mount.position;

            // Rotaciona o mount no eixo Y
            Quaternion targetRotationY = Quaternion.LookRotation(new Vector3(directionToAsteroid.x, 0, directionToAsteroid.z));
            mount.rotation = Quaternion.Euler(0, targetRotationY.eulerAngles.y, 0);

            // Rotaciona a head no eixo X
            Quaternion targetRotationX = Quaternion.LookRotation(directionToAsteroid);
            head.localRotation = Quaternion.Euler(targetRotationX.eulerAngles.x, 0, 0);
        }
    }

    // Dispara um projétil em direção ao asteroide
    private void ShootProjectile()
    {
        // Seleciona o ponto de anexo atual
        Transform attach = attachPoints[currentAttachIndex];

        // Instancia o projétil no ponto de anexo atual
        GameObject clone = Instantiate(projectile, attach.position, head.rotation);
        Rigidbody rb = clone.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(head.forward * projectileSpeed);
        }

        // Toca o som de disparo
        if (laserAudioSource != null && laserSFX != null)
        {
            laserAudioSource.Play();
        }

        // Aciona a animação de disparo
        if (turrentAnimator != null)
        {
            turrentAnimator.PlayFireAnimation();  // Chama a animação toda vez que o projétil é instanciado
        }

        // Atualiza o índice para o próximo ponto de anexo
        currentAttachIndex = (currentAttachIndex + 1) % attachPoints.Length;
    }

    private void OnDrawGizmos()
    {
        // Verifica se o asteroide mais próximo foi encontrado e desenha uma linha entre o ponto de anexo (attach) e o asteroide
        if (closestAsteroid != null)
        {
            Gizmos.color = Color.red; // Define a cor da linha
            Gizmos.DrawLine(attachPoints[currentAttachIndex].position, closestAsteroid.position);
        }
    }
}
