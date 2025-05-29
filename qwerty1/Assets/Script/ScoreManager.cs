using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Ссылка на UI-текст для отображения очков
    private int score = 0; // Текущее количество очков

    private void Start()
    {
        UpdateScoreText();
    }

    // Метод для добавления очков
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    // Обновляем текст счёта
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Очки: " + score;
        }
    }
}