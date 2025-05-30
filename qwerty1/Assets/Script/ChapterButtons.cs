using UnityEngine;
using UnityEngine.UI;

public class ChapterButtons : MonoBehaviour
{
    public Button[] chapterButtons; // ������ ������ ���� (����� 1, ����� 2...)

    private void Start()
    {
        UpdateChapterButtons();
    }

    public void UpdateChapterButtons()
    {
        for (int i = 0; i < chapterButtons.Length; i++)
        {
            // ������ ������ ��������, ������ ���� ����� �������
            chapterButtons[i].interactable = LevelManager.Instance.CanAccessLevel(i);
        }
    }
}
