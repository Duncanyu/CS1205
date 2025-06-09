using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class MissileAddon : MonoBehaviour
{
    public GameObject missilePrefab;
    public float cooldown = 8f;
    public float minRange = 3f;
    public float maxRange = 10f;

    private float lastTriggerTime = -10000000;
    private Transform playerTransform;

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

        List<EnemyDistanceData> enemyData = new List<EnemyDistanceData>(); //creating a new gameobject for each enemy and assigning a distance + position to ir
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(playerTransform.position, enemy.transform.position);
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
                    enemyData[y] = enemyData[x];
                    enemyData[y + 1] = temp;
                }
            }
        }

        //binary search even tho here its kinda inefficent
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
        //create the homing missile class, future duncan
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
