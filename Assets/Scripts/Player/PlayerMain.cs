using UnityEngine;
using System.Collections.Generic;

public class PlayerMain : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 moveInput;

    private List<KeyCode> horizontalKeys = new List<KeyCode>();
    private List<KeyCode> verticalKeys = new List<KeyCode>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; //just in case
    }

    void Update()
    {
        HandleKeyInput(KeyCode.A, horizontalKeys);
        HandleKeyInput(KeyCode.LeftArrow, horizontalKeys);
        HandleKeyInput(KeyCode.D, horizontalKeys);
        HandleKeyInput(KeyCode.RightArrow, horizontalKeys);

        HandleKeyInput(KeyCode.W, verticalKeys);
        HandleKeyInput(KeyCode.UpArrow, verticalKeys);
        HandleKeyInput(KeyCode.S, verticalKeys);
        HandleKeyInput(KeyCode.DownArrow, verticalKeys);

        moveInput = new Vector2(GetAxisFromKeys(horizontalKeys), GetAxisFromKeys(verticalKeys)).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    void HandleKeyInput(KeyCode key, List<KeyCode> keyList)
    {
        if (Input.GetKeyDown(key))
        {
            if (!keyList.Contains(key))
                keyList.Add(key);
        }

        if (Input.GetKeyUp(key))
        {
            keyList.Remove(key);
        }
    }

    int GetAxisFromKeys(List<KeyCode> keyList)
    {
        for (int i = keyList.Count - 1; i >= 0; i--)
        {
            KeyCode key = keyList[i];
            if (key == KeyCode.A || key == KeyCode.LeftArrow)
                return -1;
            else if (key == KeyCode.D || key == KeyCode.RightArrow)
                return 1;
            else if (key == KeyCode.W || key == KeyCode.UpArrow)
                return 1;
            else if (key == KeyCode.S || key == KeyCode.DownArrow)
                return -1;
        }
        return 0;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
