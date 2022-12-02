using UnityEngine;


public class CamSwitch : MonoBehaviour
{

    public GameObject planet;
    public GameObject zoomCam;
    public GameObject mainCam;
    public GameObject nearHint;
    public float dist;


    private void Start()
    {
        zoomCam.SetActive(false);
    }
    private void Update() //通过点击不同的按键实现相机的切换
    {
        
        if (Vector3.Distance(mainCam.transform.position, planet.transform.position) < dist)
        {
            nearHint.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                zoomCam.SetActive(true);
                mainCam.SetActive(false);
            }
        }
        else
        {
            nearHint.SetActive(false);
        }
      
    }
}

