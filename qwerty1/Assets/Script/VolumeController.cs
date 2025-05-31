using UnityEngine;
using UnityEngine.UI;

public class GlobalVolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;  // Ссылка на слайдер

    private void Start()
    {
        // Загружаем сохранённое значение громкости (если есть)
        if (PlayerPrefs.HasKey("GlobalVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("GlobalVolume");
            volumeSlider.value = savedVolume;
            AudioListener.volume = savedVolume;  // Применяем громкость
        }
        else
        {
            volumeSlider.value = 1f;  // Значение по умолчанию (100%)
        }

        // Подписываемся на изменение значения слайдера
        volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
    }

    // Метод для изменения громкости
    private void SetGlobalVolume(float volume)
    {
        AudioListener.volume = volume;  // Меняем общую громкость
        PlayerPrefs.SetFloat("GlobalVolume", volume);  // Сохраняем
    }
}