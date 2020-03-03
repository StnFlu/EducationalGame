using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FContainer : MonoBehaviour
{
    private List<GameObject> food;

    //Creates and spawns a new food object. This object is then stored in a list. More complex spawning will be added to justify the use of a container.
    public void SpawnFood()
    {
        GameObject x = new GameObject();
        Instantiate(x);
        food.Add(x);
    }

    //Removes a food object from the list.
    public void RemoveFood(GameObject x)
    {
        food.Remove(x);
    }

    //Compares the location passed through to all the locations of currently stored food and returns the transform of the closest one.
    public Transform CalculateNearestFood(Transform x)
    {
        Transform foodClosest = null;
        float closestFood = Mathf.Infinity;
        foreach (GameObject foodItem in food)
        {
            float distance = Vector3.Distance(x.position, foodItem.transform.position);
            if (distance < closestFood)
            {
                foodClosest = foodItem;
                closestFood = distance;
            }
        }
        return foodClosest;
    }
}
