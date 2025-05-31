using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    private Button restartButton;

    private void Start()
    {
        // Находим кнопку в сцене
        restartButton = GetComponent<Button>();
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(ResetGame);
        }
    }

    public void ResetGame()
    {
        // Сбрасываем счёт
        ScoreManager.Instance?.ResetScore();

        // Сбрасываем уровень
        LevelManager.Instance?.ResetLevelProgress();

        // Обновляем UI
        LevelManager.Instance?.UpdateUI();
        FindObjectOfType<ChapterButtons>()?.UpdateChapterButtons();
    }
}