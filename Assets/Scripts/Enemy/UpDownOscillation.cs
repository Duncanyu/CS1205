public class UpDownOscillation : MonoBehaviour
{
    public float amplitude = 1f;    // How far up/down it moves
    public float frequency = 1f;    // How fast it moves

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x, startPos.y + offset, startPos.z);
    }
}
