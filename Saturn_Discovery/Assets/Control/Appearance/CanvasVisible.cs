using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CanvasVisible : MonoBehaviour
{
    [SerializeField]
    public RectTransform panel;
    [SerializeField]
    public short myKeyCode;

    private bool isVisible = true;

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode) myKeyCode))
        {

            if (isVisible) panel.localScale = new Vector3(0, 0);
            else panel.localScale = new Vector3(1, 1);

            isVisible = !isVisible;
        }
    }
}
