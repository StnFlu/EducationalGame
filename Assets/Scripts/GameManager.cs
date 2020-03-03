using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private FContainer foodContainer;
    private List<Transform> Food;

    void Start()
    {
        Time.timeScale = 1f;
        foodContainer = FindObjectOfType<FContainer>();
        foodContainer.SpawnFood(); 
    }

    // Adjusts the speed of the game depending on the coresponding key press.
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
            Time.timeScale = 5f;
        if (Input.GetKey(KeyCode.P))
            Time.timeScale = 1f;
    }

    //Alters the speed of the game according to the passed in value.
    public void SetTimeScale(float newTimeScale)
    {
        Time.timeScale = newTimeScale;
    }
}
