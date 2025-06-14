using UnityEngine;
using TMPro;
using System.IO;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int points = 0;
    public int lives = 1;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;

    private string savePath;
    private PlayerProgress savedData;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        savePath = Application.persistentDataPath + "/player_progress.json";

        LoadData();
    }

    void Update()
    {
        if (pointsText != null) pointsText.text = "Points: " + points;
        if (livesText != null) livesText.text = "Lives: " + lives;
    }

    public void AddPoints(int amount)
    {
        points += amount;
        SaveData();
    }

    public void BuyLife()
    {
        if (points >= 10)
        {
            points -= 10;
            lives++;
            SaveData();
        }
    }

    public void TakeLife()
    {
        lives--;
        if (lives <= 0)
        {
            PlayerMain pm = GetComponent<PlayerMain>();
            pm.Die();
        }
    }

    void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            savedData = JsonUtility.FromJson<PlayerProgress>(json);
            points = savedData.currentPoints;
        }
        else
        {
            savedData = new PlayerProgress();
        }
    }

    void SaveData()
    {
        savedData.currentPoints = points;
        string json = JsonUtility.ToJson(savedData, true);
        File.WriteAllText(savePath, json);
    }

    [System.Serializable]
    public class PlayerProgress
    {
        public int currentPoints = 0;
    }
}
