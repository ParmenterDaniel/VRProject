using UnityEngine;
using UnityEngine.UI;

public class VolumeScrollbarController : MonoBehaviour
{
    private Scrollbar scrollbar;

    void Start()
    {
        // Get the Scrollbar component
        scrollbar = GetComponent<Scrollbar>();

        // Load the saved volume or set it to 1 (default)
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1.0f);

        // Set the scrollbar value and the AudioListener volume
        scrollbar.value = savedVolume;
        AudioListener.volume = savedVolume;

        // Add listener for scrollbar value changes
        scrollbar.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value; // Set the volume
        PlayerPrefs.SetFloat("Volume", value); // Save the volume for future scenes
    }
}
