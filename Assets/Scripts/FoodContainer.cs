using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodContainer : MonoBehaviour
{
    public GameObject food;
    private List<GameObject> foods;

    //Creates and spawns a new food object and currently transform it to a random position. This object is then stored in a list. More complex spawning will be added to justify the use of a container.
    public void SpawnFood()
    {
        GameObject newFood = Instantiate(food);
        AddFood(newFood);
        Vector3 randomVector = new Vector3(Random.Range(-24f, 24f), 0, Random.Range(-24f, 24f));
        newFood.transform.position = randomVector;
    }

    public void AddFood(GameObject newFood)
    {
        foods.Add(newFood);
    }

    //Removes a food object from the list.
    public void RemoveFood(GameObject newFood)
    {
        foods.Remove(newFood);
    }

    //Compares the location passed through to all the locations of currently stored food and returns the transform of the closest one.
    public Transform CalculateNearestFood(Transform currentPosition)
    {
        Transform foodClosest = null;
        float closestFood = Mathf.Infinity;
        foreach (GameObject foodItem in foods)
        {
            float distance = Vector3.Distance(currentPosition.position, foodItem.transform.position);
            if (distance < closestFood)
            {
                foodClosest = foodItem.transform;
                closestFood = distance;
            }
        }
        return foodClosest;
    }
}
