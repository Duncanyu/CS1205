using UnityEngine;
using TMPro;
using System.IO;

public class TimeSurvived : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI highscoreText;

    private float timeElapsed = 0f;
    private float highscore = 0f;
    private string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/highscore_time.txt";

        if (File.Exists(savePath))
        {
            string saved = File.ReadAllText(savePath);
            float.TryParse(saved, out highscore);
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeText != null)
        {
            timeText.text = "Time: " + Mathf.FloorToInt(timeElapsed).ToString() + "s";
        }

        if (timeElapsed > highscore)
        {
            highscore = timeElapsed;
            File.WriteAllText(savePath, highscore.ToString());
        }

        if (highscoreText != null)
        {
            highscoreText.text = "Highscore: " + Mathf.FloorToInt(highscore).ToString() + "s";
        }
    }

    public float GetTime()
    {
        return timeElapsed;
    }
}