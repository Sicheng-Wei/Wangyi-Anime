using UnityEngine;


public class CamBack : MonoBehaviour
{

    public GameObject zoomCam;
    public GameObject mainCam;

    private void Update() //通过点击不同的按键实现相机的切换
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            zoomCam.SetActive(false);
            mainCam.SetActive(true);
            GameObject.FindGameObjectWithTag("NEAR").SetActive(false);
        }
    }
}

