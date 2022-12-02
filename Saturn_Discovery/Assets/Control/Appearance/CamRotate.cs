// An highlighted block
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public Transform target;//获取旋转目标
    private int speed = 2;
    private bool dragging = false;//判断鼠标是否在滑动
    private float MaxAngle = 150;//旋转最大角度
    private float MinAngle = 100;//旋转最小角度

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            camerarotate();
        }
        camerazoom();
    }

    private void camerarotate()
    {
        var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        if (Vector3.Angle(transform.forward, Vector3.up) > MaxAngle && mouse_y > 0)
        {
            return;
        }
        if (Vector3.Angle(transform.forward, Vector3.up) < MinAngle && mouse_y < 0)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(Vector3.left * (mouse_x * 15f) * Time.deltaTime);
            transform.Translate(Vector3.up * (mouse_y * 15f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.RotateAround(target.transform.position, Vector3.up, mouse_x * speed);
            transform.RotateAround(target.transform.position, transform.right, mouse_y * speed);
        }
    }
    private void camerazoom() //摄像机滚轮缩放
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Translate(Vector3.forward * 0.5f);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Translate(Vector3.forward * -0.5f);
    }
    void OnGUI()
    {
        dragging = false;
        if (Event.current.type == EventType.MouseDrag)
        {
            dragging = true;
        }
    }
}
