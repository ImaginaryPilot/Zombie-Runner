using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightdecay = .1f;
    [SerializeField] float angledecay = 1f;
    [SerializeField] float minangle = 35f;

    Light mylight;

    private void Start()
    {
        mylight = GetComponent<Light>();
    }

    private void Update()
    {
        if(mylight.spotAngle >= minangle)
        {
            mylight.spotAngle -= angledecay * Time.deltaTime;
        }
        if (mylight.intensity >= 0.1)
        {
            mylight.intensity -= lightdecay * Time.deltaTime;
        }
    }

    public void RestoreLightIntensity(float restoreintensity)
    {
        mylight.intensity += restoreintensity;
    }

    public void RestoreLightAngle(float restoreangle)
    {
        mylight.spotAngle += restoreangle;
    }
}
