using UnityEngine;

public class ChangeSpriteOnClick : MonoBehaviour
{
    [SerializeField] private Sprite newSprite; // ����� ������
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite; // ��������� ������������ ������


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite; // ���������� ������ ������
    }

    void OnMouseDown()
    {
        spriteRenderer.sprite = (spriteRenderer.sprite == originalSprite) ? newSprite : originalSprite;
    }
}