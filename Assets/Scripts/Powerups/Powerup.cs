using UnityEngine;
using System.Collections.Generic;

public class Powerup : MonoBehaviour
{
    public WeaponBase weapon;
    void Update()
    {
        Transform origin = transform.parent;
        if (origin == null)
        {
            Debug.LogWarning("No parent object found.");
            return;
        }

        List<GameObject> enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

        BubbleSort(enemies, origin.position);

        if (enemies.Count > 0)
        {
            GameObject nearest = enemies[0];
            Debug.Log("Nearest enemy (Bubble Sort): " + nearest.name);
            Vector2 direction = (nearest.transform.position - transform.parent.position).normalized;
            weapon.Fire(direction);
        }
        else
        {
            Debug.Log("No enemies found.");
        }
    }

    void BubbleSort(List<GameObject> list, Vector2 origin)
    {
        int n = list.Count;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                float distA = Vector2.Distance(origin, list[j].transform.position);
                float distB = Vector2.Distance(origin, list[j + 1].transform.position);

                if (distA > distB)
                {
                    GameObject swap = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = swap;
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }
}
