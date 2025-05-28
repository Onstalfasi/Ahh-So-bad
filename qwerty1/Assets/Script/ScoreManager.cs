using UnityEngine;
using System.IO;
using System;

[Serializable]
public class GameData
{
    public int score;
}

public class ScoreManager : MonoBehaviour
{
    private GameData gameData;
    private string savePath;

    void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "savegame.json");
        LoadGame();
        UpdateScoreDisplay();
    }

    public void AddScore(int amount)
    {
        gameData.score += amount;
        UpdateScoreDisplay();
        SaveGame();
    }

    private void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            gameData = new GameData();
            gameData.score = 0;
        }
    }

    private void SaveGame()
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(savePath, json);
    }

    private void UpdateScoreDisplay()
    {
        // Обновление UI
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
}