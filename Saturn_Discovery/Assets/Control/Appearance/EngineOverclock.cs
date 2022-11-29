using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineOverclock : MonoBehaviour
{
    [SerializeField]
    Material engine;
    [SerializeField]
    Camera cam;

    // Update is called once per frame
    void Update()
    {
        engine.SetFloat("Emissive Intensity", cam.fieldOfView * 10);
    }
}
