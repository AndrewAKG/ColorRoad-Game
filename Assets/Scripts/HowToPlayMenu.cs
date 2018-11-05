using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HowToPlayMenu : MonoBehaviour {

    public TextMeshProUGUI controlsText;
    private string androidControls;
    private string desktopControls;

    // Use this for initialization
    void Start () {
        androidControls = "You can control the character by tilting the mobile left and right. You can pause/resume game, switch camera and turn on/off music by pressing buttons displayed on screen";

        desktopControls = "You can control the character by left, right arrows or a, d. You can pause/resume game by pressing Esc, switch camera by pressing C and turn on/off music by pressing M or by buttons displayed on screen.";

        if (Application.platform == RuntimePlatform.Android)
        {
            controlsText.SetText(androidControls);
        }
        else
        {
            controlsText.SetText(desktopControls);
        }

    }
}
