using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuNav : MonoBehaviour
{
    public Camera cam;

    public Transform menu;

    public Transform game;

    public Transform exit;
    public Transform start;

    public GameObject test;

    public bool StartGame = true;


    // Start is called before the first frame update
    void Start()
    {
        cam.transform.SetPositionAndRotation(menu.position, menu.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (StartGame)
        {



            RaycastHit hover;
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray2, out hover))
            {

                if (hover.collider.name == "StartGame")
                {


                    cam.transform.SetPositionAndRotation(Vector3.Slerp(cam.transform.position, start.position, .1f), start.rotation);

                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        test.SetActive(true);
                        StartGame = false;
                    }
                    if (hover.collider.name == "ExitGame")
                    {

                        cam.transform.LookAt(hover.collider.transform.position);
                        cam.transform.position = Vector3.Slerp(cam.transform.position, exit.position, .1f);
                    }


                }


            }
            else
            {
                cam.transform.position = Vector3.Slerp(cam.transform.position, menu.position, .1f);


            }




        }
        else
        {
            cam.transform.position = Vector3.Slerp(cam.transform.position, game.position, .1f);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, game.rotation, .1f);
        }


    }
}
