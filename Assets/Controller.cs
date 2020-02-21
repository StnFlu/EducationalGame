using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public Component[] Tools;
    public int ToolNumber;
    public Component CurrentTool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(CurrentTool);
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
            if (!(ToolNumber >= Tools.Length-1))
                ToolNumber++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
            if (!(ToolNumber <= 0))
                ToolNumber--;
            }

        CurrentTool = Tools[ToolNumber];
    }
    
}
