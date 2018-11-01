using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Camera thirdPersonCamera;
    public Camera topCamera;
    public bool camSwitch = false;

    void Start()
    {
        thirdPersonCamera.gameObject.SetActive(true);
        topCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }
	}

    public void ToggleCamera()
    {
        camSwitch = !camSwitch;
        thirdPersonCamera.gameObject.SetActive(!camSwitch);
        topCamera.gameObject.SetActive(camSwitch);
    }
}
