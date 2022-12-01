using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    // Start is called before the first frame update

    float forwardmovespeed = 6f;
    float rotatespeed = 8f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && Camera.main.fieldOfView > 40)
        {
            Camera.main.fieldOfView -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Camera.main.fieldOfView * Vector3.forward * forwardmovespeed * Time.deltaTime);
                if (Camera.main.fieldOfView < 170)
                {
                    Camera.main.fieldOfView += 1;
                }
            }
            else
            {
                transform.Translate(Vector3.forward * forwardmovespeed * Time.deltaTime);
            }
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
