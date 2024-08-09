using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovimento : MonoBehaviour
{
    [Header("Controle de Velocidade do Asteroide")]
    public float maxSpeed = 5f;
    public float minSpeed = 1f;

    [Header("Controle da Velocidade de Rotação")]
    public float rotationSpeedMax = 100f;
    public float rotationSpeedMin = 10f;

    private float rotationalSpeed;
    private Vector3 rotationAxis;
    public Vector3 movimentDirection = Vector3.forward; // Define a direção de movimento padrão
    private float asteroidSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Configura a velocidade de movimento do asteroide
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);

        // Define um eixo de rotação aleatório e velocidade de rotação
        rotationAxis = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized; // Normaliza o vetor para garantir rotação uniforme
        rotationalSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);

        // Normaliza a direção de movimento e a multiplica pela velocidade
        movimentDirection = movimentDirection.normalized * asteroidSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Move o asteroide na direção especificada
        transform.Translate(movimentDirection * Time.deltaTime, Space.World);

        // Rotaciona o asteroide ao redor do eixo definido
        transform.Rotate(rotationAxis * rotationalSpeed * Time.deltaTime, Space.World);
    }
}
