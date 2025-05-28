using UnityEngine;

public class ChangeSpriteOnClick : MonoBehaviour
{
    [SerializeField] private Sprite newSprite; // Новый спрайт
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite; // Сохраняем оригинальный спрайт


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite; // Запоминаем первый спрайт
    }

    void OnMouseDown()
    {
        spriteRenderer.sprite = (spriteRenderer.sprite == originalSprite) ? newSprite : originalSprite;
    }
}