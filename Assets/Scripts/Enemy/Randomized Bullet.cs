using UnityEngine;
using System.Collections.Generic;

public class RandomizedEnemy : MonoBehaviour {
    [Header("Enemy Settings")]
    public float speed = 5f;
    public float lifetime = 3f;

    private float[] randomNumbers;
    private int selectedNumber;
    private Vector2 direction;
    private Rigidbody2D rb;
    private float spawnTime;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
        spawnTime = Time.time;

        // Set random downward direction
        SetRandomDirection();
    }
   
    void Update() {
        // Destroy Enemy after lifetime expires
        if (Time.time - spawnTime > lifetime) 
            Destroy(gameObject);
    }

    public void FixedUpdate() {
        // Move Enemy
        if (rb != null) 
            rb.linearVelocity = direction * speed;
    }

    // Set a random downward direction
    private void SetRandomDirection() {
        // Base downward direction
        direction = Vector2.down;

        // Add some randomness (30 degrees max)
        float randomAngle = Random.Range(-30f, 30f);
        direction = Quaternion.Euler(0, 0, randomAngle) * direction;

        // Rotate bullet to face movement direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    } 

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    public void RandomNumbers() {
        // 1. Generate random numbers (10-30)
        GenerateRandomNumbers(10, 30, 5); // 5 numbers between 10-30

        // 2. Bubble sort the array
        BubbleSort(randomNumbers);

        // 3. Pick a random index
        int randomIndex = Random.Range(0, randomNumbers.Length);
        selectedNumber = (int)randomNumbers[randomIndex];

        // 4. Binary search for that number
        int foundIndex = BinarySearch(randomNumbers, selectedNumber);

        // 5. Use result as angle (-30 to 30 degrees)
        float angle = Mathf.Lerp(-30f, 30f, foundIndex / (float)randomNumbers.Length);
        direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

        // Rotate bullet to face movement direction
        float visualAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.AngleAxis(visualAngle, Vector3.forward);
    }

    public void UpdateEnemy() {
        // Move bullet
        transform.Translate(direction * speed * Time.deltaTime);

        // Destroy after lifetime
        if (Time.time - spawnTime > lifetime)
            Destroy(gameObject);
    }

    public void GenerateRandomNumbers(int min, int max, int count) {
        randomNumbers = new float[count];
        for (int i = 0; i < count; i++) {
            randomNumbers[i] = Random.Range(min, max + 1);
        }
    }

    public void BubbleSort(float[] array) {
        for (int i = 0; i < array.Length - 1; i++) {
            for (int j = 0; j < array.Length - i - 1; j++) {
                if (array[j] > array[j + 1]) {
                    // Swap
                    float temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    public int BinarySearch(float[] array, int target) {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
                return mid;

            if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1; // Not found (shouldn't happen in this case)
    }
}


