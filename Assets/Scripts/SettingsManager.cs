using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle audioToggle;
    private AudioSource backgroundMusic;

    void Start()
    {
        // Find the AudioSource component on the BackgroundMusic GameObject
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

        // Load saved audio setting
        audioToggle.isOn = PlayerPrefs.GetInt("AudioEnabled", 1) == 1;

        // Apply the initial settings
        OnAudioToggle(audioToggle);

        // Add listeners
        audioToggle.onValueChanged.AddListener(delegate { OnAudioToggle(audioToggle); });
    }

    public void OnAudioToggle(Toggle toggle)
    {
        // Save the audio setting
        PlayerPrefs.SetInt("AudioEnabled", toggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Mute or unmute the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.mute = !toggle.isOn;
        }
    }
}
