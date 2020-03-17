using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFood : MonoBehaviour
{
    Controller ct;
    public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        ct = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ct.CurrentTool == gameObject.GetComponent<PlaceFood>())
        {
            Debug.Log("hit");
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "petri")
                    {
                        Instantiate(food, hit.point, hit.transform.rotation);
                    }
                }
            }
        }
    }
}
