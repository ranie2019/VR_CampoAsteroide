using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Tamanho da �rea de gera��o")]
    public Vector3 spawnerSize;

    [Header("Taxa de gera��o (segundos)")]
    public float spawnRate = 1.0f;

    [Header("Modelos de Asteroides")]
    [SerializeField] private GameObject[] asteroidModels; // Array para armazenar diferentes modelos de asteroides

    private float spawnTimer = 0f;

    private void Update()
    {
        // Atualiza o temporizador de spawn
        spawnTimer += Time.deltaTime;

        // Verifica se � hora de gerar um novo asteroide
        if (spawnTimer >= spawnRate)
        {
            SpawnAsteroid();
            spawnTimer = 0f; // Reinicia o temporizador
        }
    }

    private void SpawnAsteroid()
    {

        // Gera uma posi��o aleat�ria dentro da �rea do spawner
        Vector3 spawnPosition = transform.position + new Vector3(
            Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2),
            Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
            Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2)
        );

        // Seleciona aleatoriamente um dos modelos de asteroide
        int randomIndex = Random.Range(0, asteroidModels.Length);
        GameObject selectedAsteroid = asteroidModels[randomIndex];

        // Instancia o asteroide selecionado na posi��o gerada
        Instantiate(selectedAsteroid, spawnPosition, Quaternion.identity);

    }

    private void OnDrawGizmos()
    {
        // Desenha a �rea do spawner no editor para visualiza��o
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, spawnerSize);
    }
}
