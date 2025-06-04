using UnityEngine;
using UnityEngine.UI;

public class EngineSoundPlayer : MonoBehaviour
{
    public AudioSource engineAudioSource;
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(PlayEngineSound);
    }

    void PlayEngineSound()
    {
        engineAudioSource.Play();
    }
}
