using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
    private FContainer foodContainer;
    private List<Transform> Food;
=======
    private FoodContainer foodContainer;
>>>>>>> Stashed changes

    void Start()
    {
        Time.timeScale = 1f;
<<<<<<< Updated upstream
        foodContainer = FindObjectOfType<FContainer>();
        foodContainer.SpawnFood(); 
=======
        foodContainer = GameObject.FindWithTag("FoodContainer").GetComponent<FoodContainer>();
        foodContainer.SpawnFood();
>>>>>>> Stashed changes
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
