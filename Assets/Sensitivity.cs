using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensitivity : OrganismBrain
{

    public Transform findNearestFood()
    {
        Transform foodClosest = null;
        float closestFood = Mathf.Infinity;
        foreach (Transform foodItem in gm.Food)
        {

            float distance = Vector3.Distance(transform.position, foodItem.transform.position);
            if (distance < closestFood)
            {
                foodClosest = foodItem;
                closestFood = distance;
            }
        }
        return foodClosest;
    }
}
