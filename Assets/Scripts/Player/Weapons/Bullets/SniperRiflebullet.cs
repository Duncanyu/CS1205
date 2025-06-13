using System;
using UnityEngine;

public class SniperRiflebullet : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 200f;
    public float lifetime = 5f;
     
    private Transform target;
    void Start()
    {
        Destroy(gameObject, lifetime);
       SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform[] ClosestEnemyList=ExchangeSort(GetEnemyLocation(), GameObject.FindGameObjectWithTag("Player").transform.position);
        Transform ClosestEnemy = BinarySearch(ClosestEnemyList, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (ClosestEnemy != null)
        {
            Vector2 direction = (ClosestEnemy.position - transform.position).normalized;//use chtgpt for this line
            transform.position += (Vector3)(direction * speed * Time.deltaTime);//use chatgpt for this line
        }
        transform.Rotate(ClosestEnemy.position);


    }
    //--------------------------------------------------------------------------------------------------------------------------
    public static Transform[] GetEnemyLocation()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        Transform[] enemyTransforms = new Transform[enemyObjects.Length];
        foreach (GameObject enemyObject in enemyObjects)
        {
            int i = 0;
            enemyTransforms[i]=enemyObjects[i].transform;
            i++;
        }
        return enemyTransforms; 
        
    }
    public static Transform BinarySearch(Transform[] Transform, Vector3 APoint)
    {
        int left = 0;
        int right = Transform.Length - 1;

        Transform closest = null;
        float closestDistance = float.MaxValue;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            float midDistance = Vector3.Distance(Transform[mid].position, APoint);

        
            if (midDistance < closestDistance)
            {
                closest = Transform[mid];
                closestDistance = midDistance;
            }

          
            if (Transform[mid].position.x < APoint.x)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return closest;
    }
    public static Transform[] ExchangeSort(Transform[] transforms, Vector3 APoint)
    {
        for (int size = 0; size < transforms.Length; size++)
        {
            for (int i = 0; i < transforms.Length - 1; i++)
            {
                float Distance1 = Vector3.Distance(transforms[i].position, APoint);
                float Distance2 = Vector3.Distance(transforms[i + 1].position, APoint);

                if (Distance1 > Distance2)
                {
                    // Swap the transforms
                    Transform temp = transforms[i];
                    transforms[i] = transforms[i + 1];
                    transforms[i + 1] = temp;
                }
            }
        }
        return transforms;
    }
    private void OnTriggerEnter2D(Collider2D apirly)
    {
        if (apirly.transform == target || apirly.CompareTag("Enemy"))
        {
            //KABLOOEY
            EnemyDeath enemyDeath = apirly.GetComponent<EnemyDeath>();
            enemyDeath.TakeDamage(20);
            Destroy(gameObject);
        }
    }

}
