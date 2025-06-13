using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPreferences : MonoBehaviour
{
    public void SwapScenes()
    {
        SceneManager.LoadScene("Preferences");
    }
}
