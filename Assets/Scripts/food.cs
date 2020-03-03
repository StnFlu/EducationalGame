using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private FContainer foodContainer;
    private float size;


    //Finds the conatiner and assigns a random value for the food size.
    void Start()
    {
        foodContainer = FindObjectOfType<FContainer>();
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
 
}
