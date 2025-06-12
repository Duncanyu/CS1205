using System.Collections.Generic;
using UnityEngine;

public class MissileAddon : MonoBehaviour
{
    public GameObject missilePrefab;
    public float cooldown = 8f;
    public float minRange = 3f;
    public float maxRange = 10f;

    private float lastTriggerTime = -10000000;
    private Transform playerTransform;

    void Start() //THIS IS ONLY TERMPORARY SO THAT I CAN SEE IT WORKS + REMOVE IT AFTER AND ONLY CALL INITIALIZE FROM SEPARATE SCRIPT WHEN PLAYER UNLOCKS THIS ABILITY
    {
        Initialize(this.transform);
    }

    public void Initialize(Transform player)
    {
        playerTransform = player;
    }

    void Update()
    {
        if (Time.time >= lastTriggerTime + cooldown)
        {
            lastTriggerTime = Time.time;
            TriggerMissile();
        }
    }

    void TriggerMissile()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); //set tag in editor wheneve ryou kmake a new enemy
        if (enemies.Length == 0) return;

        List<EnemyDistanceData> enemyData = new List<EnemyDistanceData>();
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                Debug.Log("cog,otu,wil,irrrwtbwa,ihdkhtsmwh.");
                continue;
            }

            float dist = Vector2.Distance(playerTransform.position, enemy.transform.position);
            Debug.Log(dist);
            enemyData.Add(new EnemyDistanceData(enemy.transform, dist));
        }

        //sorting aka bubble sot
        for (int x = 0; x < enemyData.Count - 1; x++)
        {
            for (int y = 0; y < enemyData.Count - x - 1; y++)
            {
                if (enemyData[y].GetDistance() > enemyData[y + 1].GetDistance())
                {
                    var temp = enemyData[y];
                    enemyData[y] = enemyData[y + 1];
                    enemyData[y + 1] = temp;
                }
            }
        }

        //bubble search cos im gonna be honest any other search would just be unnecessarily inefficient
        for (int i = 1; i < enemyData.Count; i++)
        {
            float d = enemyData[i].GetDistance();
            if (d >= minRange && d <= maxRange)
            {
                FireMissile(enemyData[i].GetTarget());
                return;
            }
        }

        Debug.Log("MA.cs | pg,irrla,iwebmahtwo");
    }

    void FireMissile(Transform target)
    {
        GameObject missile = Instantiate(missilePrefab, playerTransform.position, Quaternion.identity);
        HomingMissile hm = missile.GetComponent<HomingMissile>();
        
        hm.SetTarget(target);
    }

    private class EnemyDistanceData
    {
        private Transform Target;
        private float Distance;

        public EnemyDistanceData(Transform target, float distance)
        {
            this.Target = target;
            this.Distance = distance;
        }

        //encapsulation
        public Transform GetTarget()
        {
            return this.Target;
        }

        public float GetDistance()
        {
            return this.Distance;
        }
    }
}
