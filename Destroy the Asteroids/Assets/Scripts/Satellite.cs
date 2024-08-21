using UnityEngine;

/// <summary>
/// Rotaciona o satélite ao longo do eixo Y e faz uma órbita ao redor da posição (0, 0, 0).
/// </summary>
public class Satellite : MonoBehaviour
{
    [Tooltip("Velocidade de rotação ao longo do eixo Y")]
    public float rotationSpeed = 10f;

    [Tooltip("Velocidade de órbita ao redor da posição (0, 0, 0)")]
    public float orbitSpeed = 5f;

    [Tooltip("Raio da órbita ao redor da posição (0, 0, 0)")]
    public float orbitRadius = 10f;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Salva a posição inicial do satélite
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula a nova posição orbital
        float angle = Time.time * orbitSpeed;
        float x = Mathf.Cos(angle) * orbitRadius;
        float z = Mathf.Sin(angle) * orbitRadius;

        // Atualiza a posição do satélite em órbita
        transform.position = new Vector3(x, transform.position.y, z);

        // Rotaciona o satélite ao longo do eixo Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
