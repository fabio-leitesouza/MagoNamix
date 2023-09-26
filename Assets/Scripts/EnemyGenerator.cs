using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy;
    private float timeCounter = 0;
    public float TimeEnemyGenerator = 1;
    public LayerMask LayerEnemy; // para não gerar Enemy em cima de outro     
    public LayerMask LayerObstacle; // para evitar gerar em obstáculos
    private int maxEnemies = 6; // Número máximo de inimigos
    private int currentEnemyCount = 0; // Contagem de inimigos ativos

    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= TimeEnemyGenerator && currentEnemyCount < maxEnemies)
        {
            GenerateNewEnemy();
            timeCounter = 0;
        }
    }

    void GenerateNewEnemy()
    {
        Vector3 positionCreateEnemy;
        do
        {
            positionCreateEnemy = randomPosition();
        } while (!IsValidSpawnPosition(positionCreateEnemy));

        Instantiate(Enemy, positionCreateEnemy, transform.rotation);
        currentEnemyCount++; // Incrementa a contagem de inimigos ativos
    }

    Vector3 randomPosition()
    {
        Vector3 position = Random.insideUnitSphere * 3; // dentro de uma esfera de raio 20
        position += transform.position; // posição do gerador de Enemy
        position.y = transform.position.y; // para não gerar Enemy voando
        return position;
    }

    bool IsValidSpawnPosition(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 1, LayerEnemy); // para não criar Enemy em cima de outro
        foreach (Collider collider in colliders)
        {
            return false;
        }

        // Verifique se a posição colide com obstáculos (paredes, etc.).
        Collider[] obstacleColliders = Physics.OverlapSphere(position, 1, LayerObstacle);
        return obstacleColliders.Length == 0;
    }
}
