using UnityEngine;

public class CollisionEarth : MonoBehaviour
{
    [Header("Área de Atração")]
    [Tooltip("Raio da área de atração em que a Terra atrai os asteroides.")]
    [SerializeField] private float attractionRadius = 10f;

    [Header("Força de Atração")]
    [Tooltip("A força com que a Terra atrai os asteroides.")]
    [SerializeField] private float attractionForce = 5f;

    [Header("Multiplicador de Gravidade")]
    [Tooltip("Multiplicador para ajustar a força de atração simulando gravidade.")]
    [SerializeField] private float gravityMultiplier = 1f;

    [Header("Suavização da Atração")]
    [Tooltip("Valor para suavizar a velocidade de atração dos asteroides.")]
    [SerializeField] private float attractionSmoothing = 0.5f;

    [Header("Velocidade Máxima")]
    [Tooltip("Limite máximo de velocidade que os asteroides podem alcançar.")]
    [SerializeField] private float maxSpeed = 10f;

    private string asteroidTag = "Asteroid";

    private void Update()
    {
        AttractAsteroids();
    }

    private void AttractAsteroids()
    {
        // Encontra todos os objetos com a tag "Asteroid" dentro do raio de atração usando física
        Collider[] asteroidsInRange = Physics.OverlapSphere(transform.position, attractionRadius);

        foreach (Collider collider in asteroidsInRange)
        {
            if (collider.CompareTag(asteroidTag))
            {
                Rigidbody asteroidRigidbody = collider.GetComponent<Rigidbody>();
                if (asteroidRigidbody != null)
                {
                    // Calcula a direção e aplica a força de atração
                    Vector3 directionToEarth = (transform.position - collider.transform.position).normalized;
                    float distanceToEarth = Vector3.Distance(transform.position, collider.transform.position);

                    // Escalona a força com a distância para simular gravidade
                    float scaledForce = attractionForce / Mathf.Pow(distanceToEarth, 2) * gravityMultiplier;
                    asteroidRigidbody.velocity = Vector3.Lerp(asteroidRigidbody.velocity, directionToEarth * scaledForce, attractionSmoothing * Time.deltaTime);

                    // Limita a velocidade do asteroide
                    if (asteroidRigidbody.velocity.magnitude > maxSpeed)
                    {
                        asteroidRigidbody.velocity = asteroidRigidbody.velocity.normalized * maxSpeed;
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Desenha uma esfera na área de atração para visualização no editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attractionRadius);
    }
}
