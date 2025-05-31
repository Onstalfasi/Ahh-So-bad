using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    private Button restartButton;

    private void Start()
    {
        // ������� ������ � �����
        restartButton = GetComponent<Button>();
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(ResetGame);
        }
    }

    public void ResetGame()
    {
        // ���������� ����
        ScoreManager.Instance?.ResetScore();

        // ���������� �������
        LevelManager.Instance?.ResetLevelProgress();

        // ��������� UI
        LevelManager.Instance?.UpdateUI();
        FindObjectOfType<ChapterButtons>()?.UpdateChapterButtons();
    }
}