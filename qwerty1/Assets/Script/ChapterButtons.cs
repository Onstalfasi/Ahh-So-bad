using UnityEngine;
using UnityEngine.UI;

public class ChapterButtons : MonoBehaviour
{
    public Button[] chapterButtons; // ������ ������ ���� (����� 1, ����� 2...)
    public Button[] adUnlockButtons;

    private void Start()
    {
        UpdateChapterButtons();

        // ��������� ����������� ��� ������ �������
        for (int i = 0; i < adUnlockButtons.Length; i++)
        {
            int index = i; // ��������� ����� ��� ���������
            adUnlockButtons[i].onClick.AddListener(() => LevelManager.Instance.TryAccessLevelWithAd(index));
        }
    }

    public void UpdateChapterButtons()
    {
        for (int i = 0; i < chapterButtons.Length; i++)
        {
            bool canAccess = LevelManager.Instance.CanAccessLevel(i);
            chapterButtons[i].interactable = canAccess;

            // ���������� ������ ������� ������ ���� ������� �� ��������
            if (i < adUnlockButtons.Length)
            {
                adUnlockButtons[i].gameObject.SetActive(!canAccess);
            }
        }
    }
}
