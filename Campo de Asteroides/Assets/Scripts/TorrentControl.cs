using UnityEngine;

public class TorrentControl : MonoBehaviour
{
    // Dist�ncia m�nima para come�ar a seguir o asteroide
    public float distance = 50f;

    // Transforms que representam a cabe�a da torre e o ponto de anexo do proj�til
    public Transform head;
    public Transform attach;

    // Propriedades para o proj�til, a taxa de disparo e a velocidade do proj�til
    public GameObject projectile;
    public float fireRate = 1f;
    public float projectileSpeed = 800f;

    private Transform closestAsteroid;
    private float nextFireTime = 0f;

    private void Update()
    {
        FindClosestAsteroid();

        if (closestAsteroid != null)
        {
            RotateHeadTowardsAsteroid();

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

    // Faz a cabe�a da torre olhar para o asteroide mais pr�ximo
    private void RotateHeadTowardsAsteroid()
    {
        if (closestAsteroid != null)
        {
            head.LookAt(closestAsteroid);
        }
    }

    // Dispara um proj�til em dire��o ao asteroide
    private void ShootProjectile()
    {
        GameObject clone = Instantiate(projectile, attach.position, head.rotation);
        Rigidbody rb = clone.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(head.forward * projectileSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        // Verifica se o asteroide mais pr�ximo foi encontrado e desenha uma linha entre a torre e o asteroide
        if (closestAsteroid != null)
        {
            Gizmos.color = Color.red; // Define a cor da linha
            Gizmos.DrawLine(transform.position, closestAsteroid.position);
        }
    }
}
