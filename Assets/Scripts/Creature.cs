using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private int age;
    private int health;
    private int hunger;
    private int seconds;

<<<<<<< Updated upstream
    private bool hungry;

    private FContainer foodContainer;
    private Movement movement;

    private transform foodLocation;
=======
    private bool eating;
    private bool hungry;

    private FoodContainer foodContainer;
    private Movement movement;

    private Transform foodLocation;
>>>>>>> Stashed changes

    //Assigns other scripts to easier to call variables.
    void Start()
    {
<<<<<<< Updated upstream
        foodContainer = FindObjectOfType<FContainer>();
        movement = GetComponentInParent<Movement>();
=======
        foodContainer = GameObject.FindWithTag("FoodContainer").GetComponent<FoodContainer>();
        movement = gameObject.GetComponent<Movement>();
>>>>>>> Stashed changes
    }

    void Update()
    {
        seconds += (int)Time.deltaTime; //Increments the number of seconds passed every frame.
<<<<<<< Updated upstream
        ReduceHunger();
        IsHungry();
        LoseHealth();
        IncreaseAge();
        LookForFood();
        MoveTowardsFood();
    }


=======
        IsHungry();
        LoseHealth();
        IncreaseAge();
        if (!eating)
        {
            ReduceHunger();
            if (hungry)
                GetFood();
        }
        IsDead();
    }

>>>>>>> Stashed changes
    //Becomes hungry when the hunger value is below 60.
    void IsHungry()
    {
        if (hunger <= 60)
            hungry = true;
        else
            hungry = false;
    }

    //Reduces hunger by an increment of one every four seconds.
    void ReduceHunger()
    {
        if (seconds % 4 == 0)
            hunger--;
    }

    //Reduces health by an increment of one every four seconds and by two when hungry.
    void LoseHealth()
    {
        if (seconds % 4 == 0)
            if (hungry)
                health -= 2;
            else
                health--;
    }

    //Increases age by an increment of one every twelve seconds.
    void IncreaseAge()
    {
        if (seconds % 12 == 0)
            age++;
    }

    //There will be a function for sleeping, essentially ceasing all function for a short amount of time.

    //There will be a reproduction function that creates an new creature when certain requirements are met. This may be part of a different class.

    //Calls a function in the food container when hungry that determines the nearest food source.
<<<<<<< Updated upstream
    void LookForFood()
    {
        if (hungry)
            foodLocation = foodContainer.CalculateNearestFood();
    }

    //Calls a function from the movement scipt  to move towards a specified transform, in this case the location fo the nearest food. This will be adjusted to be more maluable and will only function when the creature is unoccupied with eating, sleeping or reproducing but will take priority over following the target.
    void MoveTowardsFood()
    {
        movement.Move(foodLocation);
    }

    //There will be collision detection here for other food as well as other creatures.
=======
    //Calls a function from the movement scipt  to move towards a specified transform, in this case the location fo the nearest food. This will be adjusted to be more maluable and will only function when the creature is unoccupied with eating, sleeping or reproducing but will take priority over following the target.
    void GetFood()
    {
        foodLocation = foodContainer.CalculateNearestFood(gameObject.transform);
        movement.BasicMove(foodLocation);
    }

    void IsDead()
    {
        if (age >= 12 || health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Food" && hungry)
        {
            eating = true;
            hunger++;
            collision.gameObject.GetComponent<Food>().ReduceFood();
        }
    }

    //There will be collision detection here for other creatures.
>>>>>>> Stashed changes
}
