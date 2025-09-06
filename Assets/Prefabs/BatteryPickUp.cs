using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    [SerializeField] float angleamount = 40f;
    [SerializeField] float intamount = 02f;
    FlashLightSystem flashLightSystem;

    private void Start()
    {
        flashLightSystem = FindObjectOfType<FlashLightSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            flashLightSystem.RestoreLightAngle(angleamount);
            flashLightSystem.RestoreLightIntensity(intamount);
            Destroy(gameObject);
        }
    }
}
