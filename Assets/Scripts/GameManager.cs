﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> Food;
    public GameObject organisms;
    public GameObject food;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        spawnOrganisms();
        Time.timeScale = 1f;
        spawnFood(10, food);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    public void addFood(GameObject x)
    {
        Food.Add(x.transform);
    }
    void spawnOrganisms()
    {
        int number = Random.Range(100, 250);
        for (int i = 0 ; i < number; i++)
        {
            Instantiate(organisms, new Vector3(2, 0, 2), transform.rotation, GameObject.Find("Organisms").transform);
        }
    }
    public void removeFood(GameObject x)
    {
        Food.Remove(x.transform);
    }
    public void setTimeScale(float newtimeScale)
    {
        Time.timeScale = newtimeScale;
    }
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y ;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
    void spawnFood(int numObjects, GameObject prefab)
    {
        Vector3 center = transform.position;
        for (int i = 0; i < numObjects/2; i++)
        {
            Vector3 pos = RandomCircle(center, 9.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(prefab, pos, rot);
        }
        for (int i = 0; i < numObjects/2; i++)
        {
            Vector3 pos = RandomCircle(center, 5.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(prefab, pos, rot);
        }
    }
}
