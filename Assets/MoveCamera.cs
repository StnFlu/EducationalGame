using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Camera cam;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Zoom(.4f);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Zoom(-0.4f);
        }


        float UpDown = Input.GetAxis("Vertical") * speed;
        float LeftRight = Input.GetAxis("Horizontal") * speed;
        UpDown *= Time.deltaTime;
        LeftRight *= Time.deltaTime;

        // Move translation along the object's z-axis
        cam.transform.Translate(LeftRight, UpDown, 0);



    }
    void Zoom(float ZoomSpeed)
    {
        cam.transform.Translate(0, 0, (ZoomSpeed * speed) * Time.deltaTime);
    }
}
