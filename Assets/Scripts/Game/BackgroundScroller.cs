using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        offset = new Vector2(0, scrollSpeed);
    }

    void Update()
    {
        rend.material.mainTextureOffset += offset * Time.deltaTime;
    }
}
