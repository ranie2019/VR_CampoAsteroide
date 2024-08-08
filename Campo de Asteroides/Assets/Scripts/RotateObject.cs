using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Velocidade p�blica inicial para a rota��o no eixo Y
    public float rotationSpeedY = 5f;

    void Update()
    {
        // Aplica a rota��o no eixo Y ao objeto
        transform.Rotate(0, rotationSpeedY * Time.deltaTime, 0);
    }
}
