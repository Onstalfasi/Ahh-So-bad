using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BallGame : MonoBehaviour
{
    [Header("Настройки игры")]
    public GameObject ballPrefab;
    public float spawnInterval = 1f;
    public float ballLifeTime = 5f;

    [Header("Границы спавна")]
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    private List<GameObject> activeBalls = new List<GameObject>();
    public static BallGame Instance { get; private set; }

    void Start()
    {
        // Запускаем спавн шариков
        InvokeRepeating("SpawnBall", 0f, spawnInterval);

    }

    IEnumerator SpawnBallsContinuously()
    {
        while (true) // Бесконечный цикл
        {
            SpawnBall();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBall()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            0
        );

        GameObject newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
        activeBalls.Add(newBall);

        // Автоматически добавляем компоненты если их нет
        if (newBall.GetComponent<Collider2D>() == null)
            newBall.AddComponent<CircleCollider2D>();

        if (newBall.GetComponent<BallController>() == null)
            newBall.AddComponent<BallController>().Initialize(ballLifeTime);
    }

    // Удаляем шарик из списка когда он уничтожается
    public void RemoveBall(GameObject ball)
    {
        activeBalls.Remove(ball);
    }
}

    