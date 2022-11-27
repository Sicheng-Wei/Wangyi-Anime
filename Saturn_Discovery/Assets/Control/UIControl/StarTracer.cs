using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class StarTracer : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;          // Main Camera
    [SerializeField]
    GameObject planetCentre;    // 3D Object
    [SerializeField]
    RectTransform guideScope;   // UI Element

    private GameObject Sun;

    // Start is called before the first frame update
    private void Start()
    {
        Sun = GameObject.FindWithTag("Sun");
        guideScope.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera Vectors
        Vector3 camDist = mainCamera.transform.position - planetCentre.transform.position;
        Vector3 camDire = mainCamera.transform.forward;
        float rou = 12000.0f / Vector3.Magnitude(camDist);

        // Detect Planet in FOV
        if (Vector3.Dot(camDist, camDire) < 0)
        {
            Vector2 screenPos = mainCamera.WorldToScreenPoint(planetCentre.transform.position);
            guideScope.position = screenPos;
            guideScope.transform.localScale = Vector3.one * rou;
        }
        else
        {
            guideScope.transform.localScale = Vector3.zero;
        }
    }
}