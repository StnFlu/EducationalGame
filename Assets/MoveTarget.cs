﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    Controller ct;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        ct = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ct.CurrentTool == gameObject.GetComponent<MoveTarget>())
        {
            Debug.Log("test");

            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {

                    target.position = hit.point;
                }
            }
        }  
    }

}
