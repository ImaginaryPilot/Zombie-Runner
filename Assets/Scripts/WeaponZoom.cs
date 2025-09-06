using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFov = 60f;
    [SerializeField] float zoomedInFov = 3f;
    [SerializeField] float zoomOutSensitivity = 5f;
    [SerializeField] float zoomInSensitivity = 1f;

    [SerializeField]RigidbodyFirstPersonController fpsController;

    bool zoomedintoggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (zoomedintoggle == false)
            {
                zoomedintoggle = true;
                fpsCamera.fieldOfView = zoomedInFov;
                fpsController.mouseLook.XSensitivity = zoomInSensitivity;
                fpsController.mouseLook.YSensitivity = zoomInSensitivity;
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomedintoggle = false;
        fpsCamera.fieldOfView = zoomedOutFov;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
}
