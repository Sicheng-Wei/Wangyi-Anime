using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMap : MonoBehaviour
{
    public GameObject roadmap;
    private bool isVisible = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isVisible) roadmap.transform.localScale = new Vector2(0.0f, 0.0f);
            else roadmap.transform.localScale = new Vector2(1.0f, 1.0f);
            isVisible = !isVisible;
        }
    }
}
