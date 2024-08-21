using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Header("Tempo de Vida do Objeto (em segundos)")]
    public float lifeTime = 5.0f; // Tempo de vida padrão de 5 segundos

    private void Start()
    {
        // Destroi o objeto após o tempo definido
        Destroy(gameObject, lifeTime);
    }
}
