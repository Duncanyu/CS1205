using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        float savedVolume = 1f;

        if (SettingsManager.Instance != null)
        {
            savedVolume = SettingsManager.Instance.settings.volume;
        }

        slider.value = savedVolume;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetVolume(savedVolume);
        }

        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float value)
    {
        Debug.Log("changed");
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetVolume(value);
        }

        if (SettingsManager.Instance != null)
        {
            SettingsManager.Instance.settings.volume = value;
            SettingsManager.Instance.SaveSettings();
        }
    }
}
