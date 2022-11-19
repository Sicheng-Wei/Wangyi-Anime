using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Vector3 centerPos;    //你围绕那个点 就用谁的角度
    private float radius = 3;     //物理离 centerPos的距离
    private float angle = 0;      //偏移角度  

    void Start()
    {
        CreateSphere();
    }


    public void CreateSphere()
    {
        centerPos = transform.position;
        //20度生成一个圆
        for (int i = 0; i < 1000; i++)
        {
            Vector3 p = Random.insideUnitSphere * radius;
            Vector3 pos = p.normalized * (2 + p.magnitude);

            GameObject obj1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //设置物体的位置Vector3三个参数分别代表x,y,z的坐标数  
            obj1.transform.position = pos;
        }
    }
}