using UnityEngine;
using UnityEngine.UI;

public class GlobalVolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;  // ������ �� �������

    private void Start()
    {
        // ��������� ���������� �������� ��������� (���� ����)
        if (PlayerPrefs.HasKey("GlobalVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("GlobalVolume");
            volumeSlider.value = savedVolume;
            AudioListener.volume = savedVolume;  // ��������� ���������
        }
        else
        {
            volumeSlider.value = 1f;  // �������� �� ��������� (100%)
        }

        // ������������� �� ��������� �������� ��������
        volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
    }

    // ����� ��� ��������� ���������
    private void SetGlobalVolume(float volume)
    {
        AudioListener.volume = volume;  // ������ ����� ���������
        PlayerPrefs.SetFloat("GlobalVolume", volume);  // ���������
    }
}