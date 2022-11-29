using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Transform player; //玩家

    private Transform watchPoint; //注视目标点
    private float watchPointHeight = 1.7f; //注视目标点高度

    private float distance = -30f; //当前 摄像机到目标点距离
    private float distanceMax = 50f; //到目标点最大距离
    private float distanceMin = 8.0f; //到目标点最小距离
    private float distanceSpeed = 3f; //距离增减速度

    private float rotationY; //水平旋转
    private float rotationYSpeed = 1.5f; //水平旋转速度

    private float AngleLerp; //当前垂直角度 插值系数
    private float AngleMax = 80.0f; //最大垂直角度
    private float AngleMin = -40.0f; //最小垂直角度
    private float AngleSpeed = 0.02f; //垂直旋转速度

    private Vector3 finalVec = new Vector3(); //最终偏移向量

    private void Start()
    {
        //寻找标签 获得玩家Transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //实例化注视目标点物体
        watchPoint = new GameObject().transform;
    }

    private void LateUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0 || Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftShift))
        {
            WheelChange();
            ChangeRotationY(); //水平旋转
            ChangeAngle(); //垂直旋转
            FinalCameraPos(); //摄像机最终位置
        }
    }

    private void WheelChange() //滚轮增减 摄像机到目标点距离
    {
        //接收鼠标滚轮输入
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //改变 当前到目标点距离
            distance += distanceSpeed;
            //限制 到目标点距离最大值
            if (distance > distanceMax)
            {
                distance = distanceMax;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //改变 当前到目标点距离
            distance -= distanceSpeed;
            //限制 到目标点距离最小值
            if (distance < distanceMin)
            {
                distance = distanceMin;
            }
        }
    }

    private void ChangeRotationY() //水平旋转
    {
        //获得鼠标X轴移动值 修改水平旋转值
        rotationY = Input.GetAxis("Mouse X") * rotationYSpeed;
        //注视目标点 水平旋转
        watchPoint.Rotate(0, rotationY, 0);
    }

    private void ChangeAngle() //垂直旋转
    {
        //鼠标Y轴移动 修改 垂直角度插值系数
        AngleLerp -= Input.GetAxis("Mouse Y") * AngleSpeed;

        //限制 垂直角度插值系数 最大最小值
        if (AngleLerp > AngleMax / 90.0f) //除90度 获得 最大 垂直角度插值系数
        {
            AngleLerp = AngleMax / 90.0f;
        }
        else if (AngleLerp < AngleMin / 90.0f)
        {
            AngleLerp = AngleMin / 90.0f;
        }

        //判断 当前垂直角度插值系数 正负
        //根据 注视目标点的 后方向量 上方或下方向量 与 当前垂直角度插值系数
        //获得 偏移向量的方向
        if (AngleLerp > 0)
            finalVec = Vector3.Lerp(-watchPoint.forward, watchPoint.up, AngleLerp);
        else
            finalVec = Vector3.Lerp(-watchPoint.forward, -watchPoint.up, -AngleLerp); //垂直角度插值系数 取正

        finalVec.Normalize(); //单位化偏移向量长度为1
        finalVec *= distance * 40f / cam.fieldOfView; //设定 偏移向量的长度
    }

    private void FinalCameraPos() //摄像机最终位置
    {
        //注视目标点位置 跟随 玩家位置
        Vector3 PointPos = player.position;
        PointPos.y += watchPointHeight; //修改 注视目标点 高度
        //弹簧移动效果 插值实现
        watchPoint.position = Vector3.Lerp(watchPoint.position, PointPos, 0.9f);

        //摄像机位置 根据注视目标点位置 进行偏移
        Vector3 cameraPos = watchPoint.position + finalVec;
        //弹簧移动效果 插值实现
        transform.position = Vector3.Lerp(transform.position, cameraPos, 0.2f);
        //摄像机始终看向 注视目标点
        transform.LookAt(watchPoint.position);
    }
}
