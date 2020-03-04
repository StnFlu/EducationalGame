using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
<<<<<<< Updated upstream
    private FContainer foodContainer;
    private float size;


    //Finds the conatiner and assigns a random value for the food size.
    void Start()
    {
        foodContainer = FindObjectOfType<FContainer>();
=======
    private FoodContainer foodContainer;
    private float size;

    //Finds the container and assigns a random value for the food size.
    void Start()
    {
        foodContainer = GameObject.FindWithTag("FoodContainer").GetComponent<FoodContainer>();
        foodContainer.AddFood(gameObject);
>>>>>>> Stashed changes
        size = Random.Range(25, 100);
    }

    //Checks whever the object needs to be destroyed every frame.
    void Update()
    {
        if (size <= 0)
        {
            foodContainer.RemoveFood(gameObject);
            Destroy(gameObject);
        }
    }

    public void ReduceFood()
    {
        size--;
    }
}
