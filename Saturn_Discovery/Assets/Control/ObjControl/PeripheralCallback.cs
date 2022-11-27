using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeripheralCallback : MonoBehaviour
{
    float movespeed = 10f;
    float rotatespeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime * 10);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * movespeed * Time.deltaTime * 10);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-1 * Vector3.up * rotatespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotatespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-1 * Vector3.forward * rotatespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(-1 * Vector3.right * rotatespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right * rotatespeed * Time.deltaTime);
        }
    }
}
