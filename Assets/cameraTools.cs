using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTools : MonoBehaviour
{
    public Camera cam;
    public Vector3 offset;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = gm.Organisms[gm.CurrentPlayer].transform.position + offset;

    }
}
