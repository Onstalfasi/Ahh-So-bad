using UnityEngine;
using UnityEngine.UI;

public class ChapterButtons : MonoBehaviour
{
    public Button[] chapterButtons; // Массив кнопок глав (Глава 1, Глава 2...)

    private void Start()
    {
        UpdateChapterButtons();
    }

    public void UpdateChapterButtons()
    {
        for (int i = 0; i < chapterButtons.Length; i++)
        {
            // Делаем кнопку активной, только если очков хватает
            chapterButtons[i].interactable = LevelManager.Instance.CanAccessLevel(i);
        }
    }
}
