using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Camera cam;
    public float speed = 10.0f;
    float rotX;
    float rotY;
    float RotSpeed = 2;
    float UpDown;
    float LeftRight;
    public float rotationSpeed = 100.0f;
    public Transform target;

    public GameObject campos;

    int index = 0;
    public Vector3[] zoomLevel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        campos.transform.position = zoomLevel[index];

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            index++;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            index--;
        }
        if(index > 2)
        {
            index = 2;
        }
        if(index < 0)
        {
            index = 0;
        }




        rotX += Input.GetAxis("Mouse X") * RotSpeed;
        rotY += Input.GetAxis("Mouse Y") * RotSpeed;
        rotY = Mathf.Clamp(rotY, -130f, -30f);

        if (Input.GetKey(KeyCode.Mouse2))
        {
            cam.transform.rotation = Quaternion.Euler(-rotY, rotX, 0f);
        }
        //Camera rotation only allowed if game us not paused



        UpDown += Input.GetAxis("Vertical") * speed * (index+1)/2;
       LeftRight += Input.GetAxis("Horizontal") * speed * (index+1)/2;
        UpDown *= Time.deltaTime;
        LeftRight *= Time.deltaTime;
        

        // Move translation along the object's z-axis
        //cam.transform.LookAt(target);
        cam.transform.Translate(LeftRight, UpDown, 0);
   
       



    }
    void Zoom(float ZoomSpeed)
    {
        cam.transform.Translate(0, 0, (ZoomSpeed * speed) * Time.deltaTime);
    }
}
