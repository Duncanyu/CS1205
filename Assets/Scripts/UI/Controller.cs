using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    public void SwitchScene() {
        SceneManager.LoadScene("game");
    }
}