using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static bool soundEnabled = true;

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.enabled = soundEnabled;
        }
    }
}
