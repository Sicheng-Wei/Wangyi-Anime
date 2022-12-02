using TMPro;
using UnityEngine;

public class StarTracer : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;          // Main Camera
    [SerializeField]
    GameObject planetCentre;    // 3D Object
    [SerializeField]
    RectTransform guideScope;   // UI Element

    private TextMeshProUGUI text;


    // Start is called before the first frame update
    private void Start()
    {
        guideScope.transform.localScale = Vector3.zero;
        text = GameObject.Find(planetCentre.name + "Tracer").GetComponentInChildren<TextMeshProUGUI>();
        text.text = planetCentre.name;
        text.transform.localPosition = new Vector3(0, 0, 0);
        text.fontSize = (int) guideScope.rect.x * guideScope.rect.y / 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera Vectors
        Vector3 camDist = mainCamera.transform.position - planetCentre.transform.position;
        Vector3 camDire = mainCamera.transform.forward;
        float rou = 20000.0f / Vector3.Magnitude(camDist);

        if(guideScope.localScale.y * guideScope.rect.width > 400.0f)
        {
            GameObject.Find(planetCentre.name + "Tracer").SetActive(false);
            return;
        }

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