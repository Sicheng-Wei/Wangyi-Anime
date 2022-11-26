using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float movespeed = 10f;
    float rotatespeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))//控制人物的移动
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movespeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-1 * Vector3.up * rotatespeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime);

        }
    }
}
