using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
    public int scoreValue = 1; // Количество очков за клик
    private ScoreManager scoreManager; // Ссылка на менеджер очков

    private void Start()
    {
        // Находим менеджер очков в сцене
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnMouseDown()
    {
        // Увеличиваем счёт
        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }

    }
}