using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public TextMeshProUGUI score;

    private void Start()
    {
        score.SetText("HALL OF FAME: " + PlayerPrefs.GetInt("HighScore"));   
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
