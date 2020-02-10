using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> Food;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
            Time.timeScale = 5f;
        if (Input.GetKey(KeyCode.P))
            Time.timeScale = 1f;
    }
    public void addFood(GameObject x)
    {
        Food.Add(x.transform);
    }
    public void removeFood(GameObject x)
    {
        Food.Remove(x.transform);
    }
    public void setTimeScale(float newtimeScale)
    {
        Time.timeScale = newtimeScale;
    }
}
