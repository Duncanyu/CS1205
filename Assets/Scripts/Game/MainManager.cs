using System.Collections;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    //aggreagation
    public EnemySpawner spawner;

    public GameObject basicEnemyPrefab;

    void Start()
    {
        StartCoroutine(RunLevel());
    }

    IEnumerator RunLevel()
    {
        yield return new WaitForSeconds(1f);
        spawner.SpawnEnemy(basicEnemyPrefab, new Vector2(0, 6));

        yield return new WaitForSeconds(2f);
        spawner.SpawnEnemy(basicEnemyPrefab, new Vector2(-2, 6));

        yield return new WaitForSeconds(1.5f);
        spawner.SpawnEnemy(basicEnemyPrefab, new Vector2(2, 6));
    }
}
