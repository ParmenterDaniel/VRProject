using UnityEngine;

public class VolumeLoader : MonoBehaviour
{
    void Start()
    {
        // Load and apply the saved volume setting
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1.0f);
        AudioListener.volume = savedVolume;
    }
}
