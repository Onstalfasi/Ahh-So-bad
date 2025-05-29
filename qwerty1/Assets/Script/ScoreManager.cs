using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // ������ �� UI-����� ��� ����������� �����
    private int score = 0; // ������� ���������� �����

    private void Start()
    {
        UpdateScoreText();
    }

    // ����� ��� ���������� �����
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    // ��������� ����� �����
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "����: " + score;
        }
    }
}