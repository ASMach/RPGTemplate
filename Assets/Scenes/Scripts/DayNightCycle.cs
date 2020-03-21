using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Adapted from http://twiik.net/articles/simplest-possible-day-night-cycle-in-unity-5
 * and modified to meet newer .NET coding standards.
 */

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    Light sun;

    [SerializeField]
    float initialIntensity = 10.0f;

    [field: SerializeField]
    float secondsPerDay
    {
        get;
    } = 60.0f;
    float currentTimeOfDay
    {
        get => currentTimeOfDay;
        set
        {
            if (currentTimeOfDay < 0.0f)
            {
                currentTimeOfDay = 0.0f;
            }
            else if (currentTimeOfDay > 1.0f)
            {
                currentTimeOfDay = 1.0f;
            }
        }
    }

    // Awake is called before start, only local setup should go here
    private void Awake()
    {
        currentTimeOfDay = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsPerDay);

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = initialIntensity * intensityMultiplier;
    }
}
