using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadScore();
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
        SaveScore();

        LevelManager.Instance?.UpdateUI();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Очки: " + score.ToString();
        }
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("SavedScore", score);
        PlayerPrefs.Save(); // Важно вызывать Save()
    }

    // Загружаем счёт
    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("SavedScore"))
        {
            score = PlayerPrefs.GetInt("SavedScore");
        }
    }

    // Очищаем сохранённые данные (например, для кнопки "Новая игра")
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("SavedScore");
        score = 0;
        UpdateScoreText();
    }
}