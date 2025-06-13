using UnityEngine;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public PlayerSettings settings = new PlayerSettings();
    private string savePath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Application.persistentDataPath + "/settings.json";
        LoadSettings();
    }

    public void SaveSettings()
    {
        string json = JsonUtility.ToJson(settings, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Saving");
        Debug.Log(savePath);
    }

    public void LoadSettings()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            settings = JsonUtility.FromJson<PlayerSettings>(json);
            // Debug.Log("Settings loaded.");
        }
        else
        {
            SaveSettings();
        }
    }
}

[System.Serializable]
public class PlayerSettings
{
    public float volume = 1f;
}
