using UnityEngine;

public class MissileAddon : MonoBehaviour
{
    public GameObject missilePrefab;
    public float cooldown = 8f;
    public float minRange = 3f;
    public float maxRange = 10f;

    private float lastTriggerTime = -10000000;
    private Transform playerTransform;

    //public void Initialize(Transform player):
}
