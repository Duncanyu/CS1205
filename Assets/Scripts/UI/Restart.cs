using UnityEngine;

public class Restart : MonoBehaviour
{
    public MainManager mm;
    public void RestartGame()
    {
        mm.Restart();
        //mm.isPaused = false;
    }
}
