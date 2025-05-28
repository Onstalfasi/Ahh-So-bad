using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGame : MonoBehaviour
{
    [Header("Настройки игры")]
    public GameObject ballPrefab;
    public float spawnInterval = 1f;
    public float ballLifeTime = 5f;

    [Header("Границы спавна")]
    public float leftBound = -8f;
    public float rightBound = 8f;
    public float bottomBound = -4f;
    public float topBound = 4f;

    void Start()
    {
        // Проверяем, чтобы префаб был назначен
        if (ballPrefab == null)
        {
            Debug.LogError("Не назначен префаб шарика!");
            return;
        }

        // Запускаем спавн шариков
        InvokeRepeating("SpawnBall", 0f, spawnInterval);
    }

    void SpawnBall()
    {
        // Создаем рандомную позицию в границах экрана
        Vector3 spawnPos = new Vector3(
            Random.Range(leftBound, rightBound),
            Random.Range(bottomBound, topBound),
            0
        );

        // Создаем шарик
        GameObject ball = Instantiate(ballPrefab, spawnPos, Quaternion.identity);

        // Добавляем коллайдер (если его нет)
        if (ball.GetComponent<Collider2D>() == null)
        {
            ball.AddComponent<CircleCollider2D>();
        }

        // Уничтожаем через заданное время
        Destroy(ball, ballLifeTime);
    }
}

// Добавляем этот компонент автоматически к каждому шарику
public class BallController : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(gameObject);
        // Можно добавить звук: AudioSource.PlayClipAtPoint(popSound, transform.position);
    }
}