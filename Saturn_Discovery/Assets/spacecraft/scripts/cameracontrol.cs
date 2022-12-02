using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    readonly Vector3 localPosition = new Vector3(0.0f, 3.0f, -30.0f);

    private Camera cam;                     //相机
    private Transform player;               //玩家
    private Transform watchPoint;           //注视目标点
    private GameObject stdObj;

    private float watchPointHeight = 0.1f;  //注视目标点高度

    private float distance = 30f;           //当前 摄像机到目标点距离
    private float distanceMax = 50f;        //到目标点最大距离
    private float distanceMin = 8f;       //到目标点最小距离
    private float distanceSpeed = 3f;       //距离增减速度

    private float rotationY;                //水平旋转
    private float rotationYSpeed = 1.5f;    //水平旋转速度

    private float AngleLerp;                //当前垂直角度 插值系数
    private float AngleMax = 80.0f;         //最大垂直角度
    private float AngleMin = -40.0f;        //最小垂直角度
    private float AngleSpeed = 0.02f;       //垂直旋转速度

    private Vector3 finalVec; //最终偏移向量

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stdObj = new GameObject();
        stdObj.transform.Rotate(0.0f, 180.0f, 0.0f);
        watchPoint = stdObj.transform;
        cam = gameObject.GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            WheelChange();
            ChangeAngle();
            FinalCameraPos();
        }
        else
        {
            cam.transform.localPosition = localPosition * 40.0f / cam.fieldOfView;
            cam.transform.localRotation = new Quaternion();
            Destroy(stdObj);
            stdObj = new GameObject();
            stdObj.transform.Rotate(0.0f, 180.0f, 0.0f);
            watchPoint = stdObj.transform;
        }
    }

    private void WheelChange()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance += distanceSpeed;
            if (distance > distanceMax) distance = distanceMax;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance -= distanceSpeed;
            if (distance < distanceMin) distance = distanceMin;
        }
    }

    private void ChangeAngle() //垂直旋转
    {
        rotationY = Input.GetAxis("Mouse X") * rotationYSpeed;
        watchPoint.Rotate(0, rotationY, 0);

        AngleLerp -= Input.GetAxis("Mouse Y") * AngleSpeed;

        if (AngleLerp > AngleMax / 90.0f) AngleLerp = AngleMax / 90.0f;
        else if (AngleLerp < AngleMin / 90.0f) AngleLerp = AngleMin / 90.0f;

        if (AngleLerp > 0) finalVec = Vector3.Lerp(-watchPoint.forward, watchPoint.up, AngleLerp);
        else finalVec = Vector3.Lerp(-watchPoint.forward, -watchPoint.up, -AngleLerp);
        finalVec.Normalize();
        finalVec *= distance * 40f / cam.fieldOfView;
    }

    private void FinalCameraPos()
    {
        Vector3 PointPos = player.position;
        PointPos.y += watchPointHeight;
        watchPoint.position = Vector3.Lerp(watchPoint.position, PointPos, 1.0f);

        Vector3 cameraPos = watchPoint.position + finalVec;
        transform.position = Vector3.Lerp(transform.position, cameraPos, 1.0f);
        transform.LookAt(watchPoint.position);
    }
}
