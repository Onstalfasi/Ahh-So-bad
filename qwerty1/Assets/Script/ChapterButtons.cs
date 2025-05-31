using UnityEngine;
using UnityEngine.UI;

public class ChapterButtons : MonoBehaviour
{
    public Button[] chapterButtons; // Массив кнопок глав (Глава 1, Глава 2...)
    public Button[] adUnlockButtons;

    private void Start()
    {
        UpdateChapterButtons();

        // Назначаем обработчики для кнопок рекламы
        for (int i = 0; i < adUnlockButtons.Length; i++)
        {
            int index = i; // Локальная копия для замыкания
            adUnlockButtons[i].onClick.AddListener(() => LevelManager.Instance.TryAccessLevelWithAd(index));
        }
    }

    public void UpdateChapterButtons()
    {
        for (int i = 0; i < chapterButtons.Length; i++)
        {
            bool canAccess = LevelManager.Instance.CanAccessLevel(i);
            chapterButtons[i].interactable = canAccess;

            // Показываем кнопку рекламы только если уровень не доступен
            if (i < adUnlockButtons.Length)
            {
                adUnlockButtons[i].gameObject.SetActive(!canAccess);
            }
        }
    }
}
