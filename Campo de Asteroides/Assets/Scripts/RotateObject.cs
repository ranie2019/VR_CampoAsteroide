using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Velocidade pública inicial para a rotação no eixo Y
    public float rotationSpeedY = 5f;

    void Update()
    {
        // Aplica a rotação no eixo Y ao objeto
        transform.Rotate(0, rotationSpeedY * Time.deltaTime, 0);
    }
}
