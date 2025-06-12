using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;

public class PlayerDataManager : MonoBehaviour {
    public Transform PlayerTransform;
    public float[] moveSpeed;
    public int Score;
    public void SaveGame() {
        PlayerData playerData = new PlayerData();
        playerData.Position = new float[] { PlayerTransform.position.x, PlayerTransform.position.y };

        string json = JsonUtility.ToJson(playerData);
        string path = Application.persistentDataPath + "/playerData.json";
        System.IO.File.WriteAllText(path, json);
    }

    public void LoadGame() {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path)) {
            string json = System.IO.File.ReadAllText(path);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            PlayerTransform.position = new Vector2(loadedData.Position[0], loadedData.Position[1]);
            Vector2 loadedPosition = new Vector2(loadedData.Position[0], loadedData.Position[1]);
            PlayerTransform.position = loadedPosition;
        }
        else
            Debug.LogWarning("File not found");
    }
}


