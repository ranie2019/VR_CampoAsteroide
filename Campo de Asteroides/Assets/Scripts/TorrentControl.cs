using UnityEngine;

public class TorrentControl : MonoBehaviour
{
    // Dist�ncia m�nima para come�ar a seguir o asteroide
    public float distance = 50f;

    // Transforms que representam a montagem (mount) da torre, a cabe�a da torre, e os pontos de anexo do proj�til
    public Transform mount;
    public Transform head;
    public Transform[] attachPoints; // Array para armazenar m�ltiplos pontos de anexo

    // Propriedades para o proj�til, a taxa de disparo e a velocidade do proj�til
    public GameObject projectile;
    public float fireRate = 1f;
    public float projectileSpeed = 800f;

    // Componente de �udio para o som de disparo
    public AudioClip laserSFX;
    private AudioSource laserAudioSource;

    // Refer�ncia ao script TurrentAnimator para acionar anima��es
    private TurrentAnimator turrentAnimator;

    private Transform closestAsteroid;
    private float nextFireTime = 0f;
    private int currentAttachIndex = 0; // �ndice para rastrear qual ponto de anexo usar

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

        // Obt�m o script TurrentAnimator do objeto atual ou de um objeto filho
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

    // Encontra o asteroide mais pr�ximo dentro do alcance
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

    // Faz a montagem (mount) da torre rotacionar no eixo Y e a cabe�a no eixo X em dire��o ao asteroide mais pr�ximo
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

    // Dispara um proj�til em dire��o ao asteroide
    private void ShootProjectile()
    {
        // Seleciona o ponto de anexo atual
        Transform attach = attachPoints[currentAttachIndex];

        // Instancia o proj�til no ponto de anexo atual
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

        // Aciona a anima��o de disparo
        if (turrentAnimator != null)
        {
            turrentAnimator.PlayFireAnimation();  // Chama a anima��o toda vez que o proj�til � instanciado
        }

        // Atualiza o �ndice para o pr�ximo ponto de anexo
        currentAttachIndex = (currentAttachIndex + 1) % attachPoints.Length;
    }

    private void OnDrawGizmos()
    {
        // Verifica se o asteroide mais pr�ximo foi encontrado e desenha uma linha entre o ponto de anexo (attach) e o asteroide
        if (closestAsteroid != null)
        {
            Gizmos.color = Color.red; // Define a cor da linha
            Gizmos.DrawLine(attachPoints[currentAttachIndex].position, closestAsteroid.position);
        }
    }
}
