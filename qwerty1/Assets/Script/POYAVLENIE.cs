using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGame : MonoBehaviour
{
    [Header("��������� ����")]
    public GameObject ballPrefab;
    public float spawnInterval = 1f;
    public float ballLifeTime = 5f;

    [Header("������� ������")]
    public float leftBound = -8f;
    public float rightBound = 8f;
    public float bottomBound = -4f;
    public float topBound = 4f;

    void Start()
    {
        // ���������, ����� ������ ��� ��������
        if (ballPrefab == null)
        {
            Debug.LogError("�� �������� ������ ������!");
            return;
        }

        // ��������� ����� �������
        InvokeRepeating("SpawnBall", 0f, spawnInterval);
    }

    void SpawnBall()
    {
        // ������� ��������� ������� � �������� ������
        Vector3 spawnPos = new Vector3(
            Random.Range(leftBound, rightBound),
            Random.Range(bottomBound, topBound),
            0
        );

        // ������� �����
        GameObject ball = Instantiate(ballPrefab, spawnPos, Quaternion.identity);

        // ��������� ��������� (���� ��� ���)
        if (ball.GetComponent<Collider2D>() == null)
        {
            ball.AddComponent<CircleCollider2D>();
        }

        // ���������� ����� �������� �����
        Destroy(ball, ballLifeTime);
    }
}

// ��������� ���� ��������� ������������� � ������� ������
public class BallController : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(gameObject);
        // ����� �������� ����: AudioSource.PlayClipAtPoint(popSound, transform.position);
    }
}