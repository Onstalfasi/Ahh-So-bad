using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Header("Level Settings")]
    public int[] levelUnlockCosts = { 10, 25, 50, 100 }; 
    public int[] levelAccessCosts = { 10, 30, 70, 100, 130, 165, 200 };   
    public int currentLevel = 0;
    public int maxLevel = 3;

    [Header("UI Elements")]
    public Text levelText;
    public Text unlockCostText;
    public Text accessCostText; 
    public Button unlockButton;
    public Button accessButton;


    public bool CanAccessLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelAccessCosts.Length)
            return false;

        return ScoreManager.Instance.score >= levelAccessCosts[levelIndex];
    }

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

        LoadLevelProgress();
    }

    private void Start()
    {
        UpdateUI();
    }

    public void TryAccessLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelAccessCosts.Length) return;

        int requiredScore = levelAccessCosts[levelIndex];

        if (ScoreManager.Instance != null && ScoreManager.Instance.score >= requiredScore)
        {
            ScoreManager.Instance.AddScore(-requiredScore);
            UpdateUI();
            FindObjectOfType<ChapterButtons>()?.UpdateChapterButtons();
        }
    }

    public void TryUnlockNextLevel()
    {
        if (currentLevel >= maxLevel) return;

        int requiredScore = levelUnlockCosts[currentLevel];

        if (ScoreManager.Instance != null && ScoreManager.Instance.score >= requiredScore)
        {
            ScoreManager.Instance.AddScore(-requiredScore);
            currentLevel++;
            SaveLevelProgress();
            UpdateUI();

            if (BallGame.Instance != null)
            {
                BallGame.Instance.spawnInterval *= 0.9f;
            }
        }
    }

    public void UpdateUI()
    {
        if (levelText != null)
            levelText.text = "Уровень: " + (currentLevel + 1);

        if (unlockCostText != null)
            unlockCostText.text = currentLevel < maxLevel ?
                "Открыть: " + levelUnlockCosts[currentLevel] + " очков" :
                "Макс. уровень";

        if (unlockButton != null)
            unlockButton.interactable = currentLevel < maxLevel &&
                                      ScoreManager.Instance.score >= levelUnlockCosts[currentLevel];
    }



    private void SaveLevelProgress()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
    }

    private void LoadLevelProgress()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
    }
}
