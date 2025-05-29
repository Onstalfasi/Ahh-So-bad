using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
    public int scoreValue = 1; // ���������� ����� �� ����
    private ScoreManager scoreManager; // ������ �� �������� �����

    private void Start()
    {
        // ������� �������� ����� � �����
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnMouseDown()
    {
        // ����������� ����
        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }

    }
}