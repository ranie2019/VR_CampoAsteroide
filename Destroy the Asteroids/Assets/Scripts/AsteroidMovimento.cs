using UnityEngine;

public class AsteroidMovimento : MonoBehaviour
{
    [Header("Controle de Velocidade do Asteroide")]
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float minSpeed = 1f;

    [Header("Controle da Velocidade de Rotação")]
    [SerializeField] private float rotationSpeedMax = 100f;
    [SerializeField] private float rotationSpeedMin = 10f;

    private float asteroidSpeed;
    private float rotationalSpeed;
    private Vector3 rotationAxis;
    private Vector3 movementDirection = Vector3.left; // Direção de movimento no eixo -X

    private void Start()
    {
        ConfigureAsteroidMovement();
        ConfigureAsteroidRotation();
    }

    private void Update()
    {
        MoveAsteroid();
        RotateAsteroid();
    }

    /// <summary>
    /// Configura a velocidade de movimento e a direção do asteroide.
    /// </summary>
    private void ConfigureAsteroidMovement()
    {
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);
        movementDirection = movementDirection.normalized * asteroidSpeed;
    }

    /// <summary>
    /// Configura o eixo e a velocidade de rotação do asteroide.
    /// </summary>
    private void ConfigureAsteroidRotation()
    {
        rotationAxis = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;

        rotationalSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }

    /// <summary>
    /// Move o asteroide na direção especificada.
    /// </summary>
    private void MoveAsteroid()
    {
        transform.Translate(movementDirection * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// Rotaciona o asteroide ao redor do eixo definido.
    /// </summary>
    private void RotateAsteroid()
    {
        transform.Rotate(rotationAxis * rotationalSpeed * Time.deltaTime, Space.World);
    }
}
