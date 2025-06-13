using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    //aggreagation
    public EnemySpawner spawner;

    public GameObject pauseButton;
    public GameObject restartButton;
    public TextMeshProUGUI puaseText;
    public bool isPaused = false;

    void Start()
    {
        Time.timeScale = isPaused ? 0f : 1f;
        //StartCoroutine(RunLevel());
    }

    //honestly im tired of doing this lets just do it in the inspector instead as a proof of concept

    // IEnumerator RunLevel()
    // {
    //     yield return new WaitForSeconds(1f);
    //     spawner.SpawnEnemy(basicEnemyPrefab, new Vector2(0, 6));

    //     yield return new WaitForSeconds(2f);
    //     spawner.SpawnEnemy(basicEnemyPrefab, new Vector2(-2, 6));

    //     yield return new WaitForSeconds(1.5f);
    //     spawner.SpawnEnemy(basicEnemyPrefab, new Vector2(2, 6));
    // }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }
    public void Restart()
    {
        isPaused = false;
        Debug.Log(isPaused);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        pauseButton.SetActive(isPaused);
        restartButton.SetActive(isPaused);
        puaseText.gameObject.SetActive(isPaused);
    }
}
