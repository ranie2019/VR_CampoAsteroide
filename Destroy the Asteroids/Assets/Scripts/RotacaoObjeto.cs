using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoObjeto : MonoBehaviour
{
    [Header("Configurações de Rotação")]
    [SerializeField] private float velocidadeRotacao = 5.0f; // Velocidade padrão de rotação

    // Update is called once per frame
    void Update()
    {
        // Rotaciona o objeto ao redor do eixo Y no sentido anti-horário (como a rotação da Terra)
        transform.Rotate(0, -velocidadeRotacao * Time.deltaTime, 0);
    }
}
